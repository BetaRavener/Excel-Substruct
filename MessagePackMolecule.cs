using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MessagePack;

namespace MessagePackFormats
{
	/// <summary>
	/// Final version of format based on MPM 3 with bonds added
	/// and coordinates changed to integers.
	/// </summary>
	[MessagePackObject]
	public class MessagePackMolecule
	{
		[Key(0)] public int[] X { get; set; }
		[Key(1)] public int[] Y { get; set; }
		[Key(2)] public Element[] Element { get; set; }
		[Key(3)] public byte[] BondCount { get; set; }
		[Key(4)] public short[] BondAtom { get; set; }
		[Key(5)] public BondType[] BondType { get; set; }
		[Key(6)] public Stereo[] BondStereo { get; set; }
		[Key(7)] public List<Tuple<short, short>> Isotope { get; set; }
		[Key(8)] public List<Tuple<short, RadicalsMultiplicity>> Radicals { get; set; }
		[Key(9)] public List<Tuple<short, sbyte>> Charge { get; set; }
	}
	
	/// <summary>
	/// Object used with version 1 for storing atom properties.
	/// </summary>
	[MessagePackObject]
	public class MessagePackAtom
	{
		[Key(0)] public double X { get; set; }
		[Key(1)] public double Y { get; set; }
		[Key(2)] public Element Element { get; set; }
		[Key(3)] public short Isotope { get; set; }
		[Key(4)] public RadicalsMultiplicity Radicals { get; set; }
		[Key(5)] public sbyte Charge { get; set; }
	}

	/// <summary>
	/// MPM 1.
	/// Atom properties are stored in separate objects.
	/// </summary>
	[MessagePackObject]
	public class MessagePackMolecule1
	{
		[Key(0)] public virtual MessagePackAtom[] Atoms { get; set; }
	}

	/// <summary>
	/// MPM 2.
	/// Atom properties are stored in arrays that are common
	/// for whole chemical structure. All arrays are dense.
	/// </summary>
	[MessagePackObject]
	public class MessagePackMolecule2
	{
		[Key(0)] public double[] X { get; set; }
		[Key(1)] public double[] Y { get; set; }
		[Key(2)] public Element[] Element { get; set; }
		[Key(3)] public short[] Isotope { get; set; }
		[Key(4)] public RadicalsMultiplicity[] Radicals { get; set; }
		[Key(5)] public sbyte[] Charge { get; set; }
	}

	/// <summary>
	/// MPM 3.
	/// Atom properties are stored in arrays that are common
	/// for whole chemical structure. Coordinate and element
	/// arrays are dense. Less common atom properties are stored
	/// as sparse arrays.
	/// </summary>
	[MessagePackObject]
	public class MessagePackMolecule3
	{
		[Key(0)] public double[] X { get; set; }
		[Key(1)] public double[] Y { get; set; }
		[Key(2)] public Element[] Element { get; set; }
		[Key(7)] public List<Tuple<short, short>> Isotope { get; set; }
		[Key(8)] public List<Tuple<short, RadicalsMultiplicity>> Radicals { get; set; }
		[Key(9)] public List<Tuple<short, sbyte>> Charge { get; set; }
	}

	/// <summary>
	/// MPM 4.
	/// Atom properties are stored in arrays that are common
	/// for whole chemical structure. Coordinate and element
	/// arrays are dense. All sp common atom properties are stored
	/// are encoded into single short and stored in sparse array.
	/// </summary>
	[MessagePackObject]
	public class MessagePackMolecule4
	{
		[Key(0)] public double[] X { get; set; }
		[Key(1)] public double[] Y { get; set; }
		[Key(2)] public Element[] Element { get; set; }
		[Key(3)] public List<Tuple<short, short>> Special { get; set; }
	}
}