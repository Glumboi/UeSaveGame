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

namespace UeSaveGame.DataTypes
{
	public class Transform
    {
        public Quaternion Rotation;
        public Vector Translation;
        public Vector Scale;

        public static Transform Deserialize(BinaryReader reader)
        {
            Transform t = new Transform();

            t.Rotation.X = reader.ReadSingle();
            t.Rotation.Y = reader.ReadSingle();
            t.Rotation.Z = reader.ReadSingle();
            t.Rotation.W = reader.ReadSingle();

            t.Translation.X = reader.ReadSingle();
            t.Translation.Y = reader.ReadSingle();
            t.Translation.Z = reader.ReadSingle();

            t.Scale.X = reader.ReadSingle();
            t.Scale.Y = reader.ReadSingle();
            t.Scale.Z = reader.ReadSingle();

            return t;
        }

        public long Serialize(BinaryWriter writer)
        {
            writer.Write(Rotation.X);
            writer.Write(Rotation.Y);
            writer.Write(Rotation.Z);
            writer.Write(Rotation.W);

            writer.Write(Translation.X);
            writer.Write(Translation.Y);
            writer.Write(Translation.Z);

            writer.Write(Scale.X);
            writer.Write(Scale.Y);
            writer.Write(Scale.Z);

            return 40;
        }

        public override string ToString()
        {
            return $"R({Rotation}) T({Translation}) S({Scale})";
        }
    }
}
