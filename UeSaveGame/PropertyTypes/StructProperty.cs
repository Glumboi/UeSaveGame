﻿// Copyright 2022 Crystal Ferrai
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Reflection;
using UeSaveGame.StructData;
using UeSaveGame.Util;

namespace UeSaveGame.PropertyTypes
{
	public class StructProperty : UProperty<IStructData>
    {
        private static readonly Dictionary<string, Type> sTypeMap;
        private static readonly Dictionary<string, Type> sNameMap;

        public FString? StructType { get; set; }

        public Guid StructGuid { get; set; }

        static StructProperty()
        {
            sTypeMap = new Dictionary<string, Type>();
            sNameMap = new Dictionary<string, Type>();

            // TODO: GlobalAssemblyCache is always false now. Find another way tro filter out assemblies we don't care about
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies().Where(a => a.GlobalAssemblyCache == false))
            {
                IEnumerable<Type> types = assembly.GetTypes().Where(t => !t.IsAbstract && t.GetInterfaces().Contains(typeof(IStructData)));
                foreach (Type type in types)
                {
                    IStructData instance = (IStructData?)Activator.CreateInstance(type) ?? throw new MissingMethodException($"Could not construct an instance of struct data type {type.FullName}.");
                    foreach (string structType in instance.StructTypes)
                    {
                        sTypeMap.Add(structType, type);
                    }
                    if (instance.KnownPropertyNames != null)
                    {
                        foreach (string structType in instance.KnownPropertyNames)
                        {
                            sNameMap.Add(structType, type);
                        }
                    }
                }
            }
        }

        public StructProperty(FString name, FString type)
            : base(name, type)
        {
        }

        public override void Deserialize(BinaryReader reader, long size, bool includeHeader)
        {
            if (includeHeader)
            {
                StructType = reader.ReadUnrealString();
                byte[] guidBytes = reader.ReadBytes(16);
                StructGuid = new Guid(guidBytes);
                reader.ReadByte(); // terminator
            }

            if (size > 0 || StructType == null && !includeHeader)
            {
                IStructData instance;
                Type? type;
                if (StructType != null && sTypeMap.TryGetValue(StructType!, out type) ||
                    StructType == null && Name != null && sNameMap.TryGetValue(Name!, out type))
                {
                    instance = (IStructData?)Activator.CreateInstance(type) ?? throw new MissingMethodException($"Could not construct an instance of struct data type {type.FullName}.");
                }
                else
                {
                    instance = new PropertiesStruct();
                }
                instance.Deserialize(reader, size);
                Value = instance;
            }
            else
            {
                Value = null;
            }
        }

        public override long Serialize(BinaryWriter writer,  bool includeHeader)
        {
            if (includeHeader)
            {
                writer.WriteUnrealString(StructType);
                writer.Write(StructGuid.ToByteArray());
                writer.Write((byte)0);
            }

            if (Value != null)
            {
                return Value.Serialize(writer);
            }
            return 0;
        }

        public override string ToString()
        {
            return Value == null ? base.ToString() : $"{Name} [{nameof(StructProperty)} - {StructType??"no type"}] {Value?.ToString() ?? "Null"}";
        }
    }
}
