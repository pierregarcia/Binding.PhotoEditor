using System;
using System.Runtime.InteropServices;
using AVFoundation;
using AudioToolbox;
using AudioUnit;
using CoreAnimation;
using CoreFoundation;
using CoreGraphics;
using CoreLocation;
using CoreMedia;
using CoreText;
using CoreVideo;
using Foundation;
using GLKit;
using IOSurface;
using ImageIO;
using MediaToolbox;
using Metal;
using ModelIO;
using ObjCRuntime;
using OpenGLES;
using Security;
using UIKit;

namespace PhotoEditor
{
	[Native]
	public enum RecordingMode : ulong
	{
		Photo = 0,
		Video = 1
	}

	[Native]
	public enum PESDKRenderMode : ulong
	{
		None = 0,
		AutoEnhancement = 1 << 0,
		Transform = 1 << 1,
		Focus = 1 << 2,
		PhotoEffect = 1 << 3,
		ColorAdjustments = 1 << 4,
		Sprites = 1 << 5,
		Inset = 1 << 6,
		Overlay = 1 << 7,
		All = AutoEnhancement | Transform | Focus | PhotoEffect | ColorAdjustments | Sprites | Inset | Overlay
	}

	[Native]
	public enum PESDKStickerTintMode : ulong
	{
		None = 0,
		Solid = 1,
		Colorized = 2
	}

	[Native]
	public enum TextDesignOverlayAction : ulong
	{
		Invert = 0,
		Delete = 1,
		Undo = 2,
		Redo = 3,
		BringToFront = 4
	}

	[Native]
	public enum BrushTool : ulong
	{
		Color = 0,
		Size = 1,
		Hardness = 2,
		BringToFront = 3
	}

	[Native]
	public enum BrushOverlayAction : ulong
	{
		Undo = 0,
		Redo = 1,
		Delete = 2
	}

	[Native]
	public enum AdjustTool : ulong
	{
		Brightness = 0,
		Contrast = 1,
		Saturation = 2,
		Shadows = 3,
		Highlights = 4,
		Exposure = 5,
		Clarity = 6,
		Gamma = 7,
		Blacks = 8,
		Whites = 9,
		Temperature = 10
	}

	[Native]
	public enum TextAction : ulong
	{
		SelectFont = 0,
		SelectColor = 1,
		SelectBackgroundColor = 2,
		SelectAlignment = 3,
		Flip = 4,
		Straighten = 5,
		BringToFront = 6
	}

	[Native]
	public enum TextOverlayAction : ulong
	{
		Add = 0,
		Delete = 1,
		Undo = 2,
		Redo = 3
	}

	[Native]
	public enum PESDKFocusType : ulong
	{
		Off = 0,
		Linear = 1,
		Radial = 2,
		Gradient = 3,
		Gaussian = 4
	}

	[Native]
	public enum PESDKFocusMode : ulong
	{
		Off = 0,
		Radial = 1,
		Mirrored = 2,
		Linear = 3,
		Gaussian = 4
	}

	[Native]
	public enum TransformAction : ulong
	{
		RotateLeft = 0,
		FlipHorizontally = 1,
		Straighten = 2
	}

	[Native]
	public enum StickerAction : ulong
	{
		SelectColor = 0,
		Flip = 1,
		Straighten = 2,
		BringToFront = 3,
		Brightness = 4,
		Contrast = 5,
		Saturation = 6
	}

	[Native]
	public enum StickerOverlayAction : ulong
	{
		Add = 0,
		Delete = 1,
		Undo = 2,
		Redo = 3
	}

	[Native]
	public enum PESDKBlendMode : ulong
	{
		Normal = 0,
		Overlay = 1,
		SoftLight = 2,
		HardLight = 3,
		Multiply = 4,
		Darken = 5,
		ColorBurn = 6,
		Screen = 7,
		Lighten = 8
	}

	[Native]
	public enum PESDKImageFileFormat : ulong
	{
		Jpeg = 0,
		Png = 1,
		Heif = 2,
		Tiff = 3
	}

	[Native]
	public enum PhotoEditOverlayAction : ulong
	{
		Undo = 0,
		Redo = 1
	}

	[Native]
	public enum PESDKOrientation : ulong
	{
		Normal = 1,
		FlipX = 2,
		Rotate180 = 3,
		FlipY = 4,
		Transverse = 5,
		Rotate90 = 6,
		Transpose = 7,
		Rotate270 = 8
	}

	[Native]
	public enum BlurQuality : ulong
	{
		Low = 0,
		High = 1
	}

	[Mac(10, 14), iOS(12, 0)]
	[Native]
	public enum MTLIndirectCommandType : ulong
	{
		MTLIndirectCommandTypeDraw = (1 << 0),
		Indexed = (1 << 1),
		Patches = (1 << 2),
		IndexedPatches = (1 << 3)
	}

	[Mac(10, 14), iOS(12, 0)]
	[Native]
	public enum MTLDispatchType : ulong
	{
		Serial,
		Concurrent
	}

	[Mac(10, 14), iOS(12, 0)]
	[Native]
	public enum MTLBarrierScope : ulong
	{
		Buffers = 1 << 0,
		Textures = 1 << 1,
		RenderTargets = 1 << 2
	}

	[Mac(10, 11), iOS(8, 0)]
	[Native]
	public enum MTLCPUCacheMode : ulong
	{
		DefaultCache = 0,
		WriteCombined = 1
	}
}
