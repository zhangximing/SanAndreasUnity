﻿using System;
using System.IO;

namespace SanAndreasUnity.Importing.Sections
{
    [SectionType(26)]
    internal class GeometryList : SectionData
    {
        public readonly UInt32 GeometryCount;
        public readonly Geometry[] Geometry;

        public GeometryList(SectionHeader header, Stream stream)
        {
            var data = Section<Data>.ReadData(stream);

            GeometryCount = BitConverter.ToUInt32(data.Value, 0);
            Geometry = new Geometry[GeometryCount];

            for (var i = 0; i < GeometryCount; ++i) {
                Geometry[i] = Section<Geometry>.ReadData(stream);
            }
        }
    }
}