; ModuleID = 'compressed_assemblies.armeabi-v7a.ll'
source_filename = "compressed_assemblies.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android21"

%struct.CompressedAssemblyDescriptor = type {
	i32, ; uint32_t uncompressed_file_size
	i1, ; bool loaded
	i32 ; uint32_t buffer_offset
}

@compressed_assembly_count = dso_local local_unnamed_addr constant i32 324, align 4

@compressed_assembly_descriptors = dso_local local_unnamed_addr global [324 x %struct.CompressedAssemblyDescriptor] [
	%struct.CompressedAssemblyDescriptor {
		i32 543744, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 0; uint32_t buffer_offset
	}, ; 0: Ruzgar
	%struct.CompressedAssemblyDescriptor {
		i32 120616, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 543744; uint32_t buffer_offset
	}, ; 1: CommunityToolkit.Mvvm
	%struct.CompressedAssemblyDescriptor {
		i32 174128, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 664360; uint32_t buffer_offset
	}, ; 2: GoogleGson
	%struct.CompressedAssemblyDescriptor {
		i32 45320, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 838488; uint32_t buffer_offset
	}, ; 3: Microsoft.Extensions.Configuration
	%struct.CompressedAssemblyDescriptor {
		i32 28984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 883808; uint32_t buffer_offset
	}, ; 4: Microsoft.Extensions.Configuration.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 96008, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 912792; uint32_t buffer_offset
	}, ; 5: Microsoft.Extensions.DependencyInjection
	%struct.CompressedAssemblyDescriptor {
		i32 66312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1008800; uint32_t buffer_offset
	}, ; 6: Microsoft.Extensions.DependencyInjection.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 31504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1075112; uint32_t buffer_offset
	}, ; 7: Microsoft.Extensions.Diagnostics.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 23864, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1106616; uint32_t buffer_offset
	}, ; 8: Microsoft.Extensions.FileProviders.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 54536, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1130480; uint32_t buffer_offset
	}, ; 9: Microsoft.Extensions.Hosting.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 52016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1185016; uint32_t buffer_offset
	}, ; 10: Microsoft.Extensions.Logging
	%struct.CompressedAssemblyDescriptor {
		i32 67344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1237032; uint32_t buffer_offset
	}, ; 11: Microsoft.Extensions.Logging.Abstractions
	%struct.CompressedAssemblyDescriptor {
		i32 65848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1304376; uint32_t buffer_offset
	}, ; 12: Microsoft.Extensions.Options
	%struct.CompressedAssemblyDescriptor {
		i32 45328, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1370224; uint32_t buffer_offset
	}, ; 13: Microsoft.Extensions.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 1928504, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 1415552; uint32_t buffer_offset
	}, ; 14: Microsoft.Maui.Controls
	%struct.CompressedAssemblyDescriptor {
		i32 135432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3344056; uint32_t buffer_offset
	}, ; 15: Microsoft.Maui.Controls.Xaml
	%struct.CompressedAssemblyDescriptor {
		i32 862208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 3479488; uint32_t buffer_offset
	}, ; 16: Microsoft.Maui
	%struct.CompressedAssemblyDescriptor {
		i32 280848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 4341696; uint32_t buffer_offset
	}, ; 17: Microsoft.Maui.Essentials
	%struct.CompressedAssemblyDescriptor {
		i32 208696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 4622544; uint32_t buffer_offset
	}, ; 18: Microsoft.Maui.Graphics
	%struct.CompressedAssemblyDescriptor {
		i32 712464, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 4831240; uint32_t buffer_offset
	}, ; 19: Newtonsoft.Json
	%struct.CompressedAssemblyDescriptor {
		i32 1176064, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 5543704; uint32_t buffer_offset
	}, ; 20: Xamarin.Android.Glide
	%struct.CompressedAssemblyDescriptor {
		i32 15944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 6719768; uint32_t buffer_offset
	}, ; 21: Xamarin.Android.Glide.Annotations
	%struct.CompressedAssemblyDescriptor {
		i32 25632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 6735712; uint32_t buffer_offset
	}, ; 22: Xamarin.Android.Glide.DiskLruCache
	%struct.CompressedAssemblyDescriptor {
		i32 63032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 6761344; uint32_t buffer_offset
	}, ; 23: Xamarin.Android.Glide.GifDecoder
	%struct.CompressedAssemblyDescriptor {
		i32 186880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 6824376; uint32_t buffer_offset
	}, ; 24: Xamarin.AndroidX.Activity
	%struct.CompressedAssemblyDescriptor {
		i32 15928, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7011256; uint32_t buffer_offset
	}, ; 25: Xamarin.AndroidX.Activity.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 15912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7027184; uint32_t buffer_offset
	}, ; 26: Xamarin.AndroidX.Annotation
	%struct.CompressedAssemblyDescriptor {
		i32 38432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7043096; uint32_t buffer_offset
	}, ; 27: Xamarin.AndroidX.Annotation.Experimental
	%struct.CompressedAssemblyDescriptor {
		i32 215608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7081528; uint32_t buffer_offset
	}, ; 28: Xamarin.AndroidX.Annotation.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 1293312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 7297136; uint32_t buffer_offset
	}, ; 29: Xamarin.AndroidX.AppCompat
	%struct.CompressedAssemblyDescriptor {
		i32 93184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8590448; uint32_t buffer_offset
	}, ; 30: Xamarin.AndroidX.AppCompat.AppCompatResources
	%struct.CompressedAssemblyDescriptor {
		i32 38984, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8683632; uint32_t buffer_offset
	}, ; 31: Xamarin.AndroidX.Arch.Core.Common
	%struct.CompressedAssemblyDescriptor {
		i32 28192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8722616; uint32_t buffer_offset
	}, ; 32: Xamarin.AndroidX.Arch.Core.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 399360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 8750808; uint32_t buffer_offset
	}, ; 33: Xamarin.AndroidX.Browser
	%struct.CompressedAssemblyDescriptor {
		i32 35400, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9150168; uint32_t buffer_offset
	}, ; 34: Xamarin.AndroidX.CardView
	%struct.CompressedAssemblyDescriptor {
		i32 15944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9185568; uint32_t buffer_offset
	}, ; 35: Xamarin.AndroidX.Collection
	%struct.CompressedAssemblyDescriptor {
		i32 628768, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9201512; uint32_t buffer_offset
	}, ; 36: Xamarin.AndroidX.Collection.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 15904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9830280; uint32_t buffer_offset
	}, ; 37: Xamarin.AndroidX.Collection.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 36424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9846184; uint32_t buffer_offset
	}, ; 38: Xamarin.AndroidX.Concurrent.Futures
	%struct.CompressedAssemblyDescriptor {
		i32 741888, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 9882608; uint32_t buffer_offset
	}, ; 39: Xamarin.AndroidX.ConstraintLayout
	%struct.CompressedAssemblyDescriptor {
		i32 1466936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 10624496; uint32_t buffer_offset
	}, ; 40: Xamarin.AndroidX.ConstraintLayout.Core
	%struct.CompressedAssemblyDescriptor {
		i32 102400, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12091432; uint32_t buffer_offset
	}, ; 41: Xamarin.AndroidX.CoordinatorLayout
	%struct.CompressedAssemblyDescriptor {
		i32 2224640, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 12193832; uint32_t buffer_offset
	}, ; 42: Xamarin.AndroidX.Core
	%struct.CompressedAssemblyDescriptor {
		i32 216608, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14418472; uint32_t buffer_offset
	}, ; 43: Xamarin.AndroidX.Core.Core.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 20016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14635080; uint32_t buffer_offset
	}, ; 44: Xamarin.AndroidX.Core.ViewTree
	%struct.CompressedAssemblyDescriptor {
		i32 64040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14655096; uint32_t buffer_offset
	}, ; 45: Xamarin.AndroidX.CursorAdapter
	%struct.CompressedAssemblyDescriptor {
		i32 74776, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14719136; uint32_t buffer_offset
	}, ; 46: Xamarin.AndroidX.CustomView
	%struct.CompressedAssemblyDescriptor {
		i32 15360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14793912; uint32_t buffer_offset
	}, ; 47: Xamarin.AndroidX.CustomView.PoolingContainer
	%struct.CompressedAssemblyDescriptor {
		i32 57856, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14809272; uint32_t buffer_offset
	}, ; 48: Xamarin.AndroidX.DrawerLayout
	%struct.CompressedAssemblyDescriptor {
		i32 62976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14867128; uint32_t buffer_offset
	}, ; 49: Xamarin.AndroidX.DynamicAnimation
	%struct.CompressedAssemblyDescriptor {
		i32 288816, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 14930104; uint32_t buffer_offset
	}, ; 50: Xamarin.AndroidX.Emoji2
	%struct.CompressedAssemblyDescriptor {
		i32 26144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15218920; uint32_t buffer_offset
	}, ; 51: Xamarin.AndroidX.Emoji2.ViewsHelper
	%struct.CompressedAssemblyDescriptor {
		i32 73288, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15245064; uint32_t buffer_offset
	}, ; 52: Xamarin.AndroidX.ExifInterface
	%struct.CompressedAssemblyDescriptor {
		i32 375808, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15318352; uint32_t buffer_offset
	}, ; 53: Xamarin.AndroidX.Fragment
	%struct.CompressedAssemblyDescriptor {
		i32 27192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15694160; uint32_t buffer_offset
	}, ; 54: Xamarin.AndroidX.Fragment.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 26152, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15721352; uint32_t buffer_offset
	}, ; 55: Xamarin.AndroidX.Interpolator
	%struct.CompressedAssemblyDescriptor {
		i32 16952, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15747504; uint32_t buffer_offset
	}, ; 56: Xamarin.AndroidX.Lifecycle.Common
	%struct.CompressedAssemblyDescriptor {
		i32 71200, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15764456; uint32_t buffer_offset
	}, ; 57: Xamarin.AndroidX.Lifecycle.Common.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 39464, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15835656; uint32_t buffer_offset
	}, ; 58: Xamarin.AndroidX.Lifecycle.LiveData
	%struct.CompressedAssemblyDescriptor {
		i32 36936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15875120; uint32_t buffer_offset
	}, ; 59: Xamarin.AndroidX.Lifecycle.LiveData.Core
	%struct.CompressedAssemblyDescriptor {
		i32 16440, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15912056; uint32_t buffer_offset
	}, ; 60: Xamarin.AndroidX.Lifecycle.LiveData.Core.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 22584, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15928496; uint32_t buffer_offset
	}, ; 61: Xamarin.AndroidX.Lifecycle.Process
	%struct.CompressedAssemblyDescriptor {
		i32 15416, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15951080; uint32_t buffer_offset
	}, ; 62: Xamarin.AndroidX.Lifecycle.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 44032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 15966496; uint32_t buffer_offset
	}, ; 63: Xamarin.AndroidX.Lifecycle.Runtime.Android
	%struct.CompressedAssemblyDescriptor {
		i32 15904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16010528; uint32_t buffer_offset
	}, ; 64: Xamarin.AndroidX.Lifecycle.Runtime.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 16456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16026432; uint32_t buffer_offset
	}, ; 65: Xamarin.AndroidX.Lifecycle.Runtime.Ktx.Android
	%struct.CompressedAssemblyDescriptor {
		i32 16928, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16042888; uint32_t buffer_offset
	}, ; 66: Xamarin.AndroidX.Lifecycle.ViewModel
	%struct.CompressedAssemblyDescriptor {
		i32 88632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16059816; uint32_t buffer_offset
	}, ; 67: Xamarin.AndroidX.Lifecycle.ViewModel.Android
	%struct.CompressedAssemblyDescriptor {
		i32 16440, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16148448; uint32_t buffer_offset
	}, ; 68: Xamarin.AndroidX.Lifecycle.ViewModel.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 15928, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16164888; uint32_t buffer_offset
	}, ; 69: Xamarin.AndroidX.Lifecycle.ViewModelSavedState
	%struct.CompressedAssemblyDescriptor {
		i32 48200, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16180816; uint32_t buffer_offset
	}, ; 70: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.Android
	%struct.CompressedAssemblyDescriptor {
		i32 61440, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16229016; uint32_t buffer_offset
	}, ; 71: Xamarin.AndroidX.Loader
	%struct.CompressedAssemblyDescriptor {
		i32 15904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16290456; uint32_t buffer_offset
	}, ; 72: Xamarin.AndroidX.Navigation.Common
	%struct.CompressedAssemblyDescriptor {
		i32 233016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16306360; uint32_t buffer_offset
	}, ; 73: Xamarin.AndroidX.Navigation.Common.Android
	%struct.CompressedAssemblyDescriptor {
		i32 60960, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16539376; uint32_t buffer_offset
	}, ; 74: Xamarin.AndroidX.Navigation.Fragment
	%struct.CompressedAssemblyDescriptor {
		i32 15928, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16600336; uint32_t buffer_offset
	}, ; 75: Xamarin.AndroidX.Navigation.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 114688, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16616264; uint32_t buffer_offset
	}, ; 76: Xamarin.AndroidX.Navigation.Runtime.Android
	%struct.CompressedAssemblyDescriptor {
		i32 47104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16730952; uint32_t buffer_offset
	}, ; 77: Xamarin.AndroidX.Navigation.UI
	%struct.CompressedAssemblyDescriptor {
		i32 52784, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16778056; uint32_t buffer_offset
	}, ; 78: Xamarin.AndroidX.ProfileInstaller.ProfileInstaller
	%struct.CompressedAssemblyDescriptor {
		i32 660992, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 16830840; uint32_t buffer_offset
	}, ; 79: Xamarin.AndroidX.RecyclerView
	%struct.CompressedAssemblyDescriptor {
		i32 30792, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17491832; uint32_t buffer_offset
	}, ; 80: Xamarin.AndroidX.ResourceInspection.Annotation
	%struct.CompressedAssemblyDescriptor {
		i32 15912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17522624; uint32_t buffer_offset
	}, ; 81: Xamarin.AndroidX.SavedState
	%struct.CompressedAssemblyDescriptor {
		i32 91688, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17538536; uint32_t buffer_offset
	}, ; 82: Xamarin.AndroidX.SavedState.SavedState.Android
	%struct.CompressedAssemblyDescriptor {
		i32 16416, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17630224; uint32_t buffer_offset
	}, ; 83: Xamarin.AndroidX.SavedState.SavedState.Ktx
	%struct.CompressedAssemblyDescriptor {
		i32 46648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17646640; uint32_t buffer_offset
	}, ; 84: Xamarin.AndroidX.Security.SecurityCrypto
	%struct.CompressedAssemblyDescriptor {
		i32 40448, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17693288; uint32_t buffer_offset
	}, ; 85: Xamarin.AndroidX.SlidingPaneLayout
	%struct.CompressedAssemblyDescriptor {
		i32 31304, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17733736; uint32_t buffer_offset
	}, ; 86: Xamarin.AndroidX.Startup.StartupRuntime
	%struct.CompressedAssemblyDescriptor {
		i32 67584, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17765040; uint32_t buffer_offset
	}, ; 87: Xamarin.AndroidX.SwipeRefreshLayout
	%struct.CompressedAssemblyDescriptor {
		i32 15392, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17832624; uint32_t buffer_offset
	}, ; 88: Xamarin.AndroidX.Tracing.Tracing
	%struct.CompressedAssemblyDescriptor {
		i32 24104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17848016; uint32_t buffer_offset
	}, ; 89: Xamarin.AndroidX.Tracing.Tracing.Android
	%struct.CompressedAssemblyDescriptor {
		i32 175104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 17872120; uint32_t buffer_offset
	}, ; 90: Xamarin.AndroidX.Transition
	%struct.CompressedAssemblyDescriptor {
		i32 36384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18047224; uint32_t buffer_offset
	}, ; 91: Xamarin.AndroidX.VectorDrawable
	%struct.CompressedAssemblyDescriptor {
		i32 49184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18083608; uint32_t buffer_offset
	}, ; 92: Xamarin.AndroidX.VectorDrawable.Animated
	%struct.CompressedAssemblyDescriptor {
		i32 122936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18132792; uint32_t buffer_offset
	}, ; 93: Xamarin.AndroidX.VersionedParcelable
	%struct.CompressedAssemblyDescriptor {
		i32 86016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18255728; uint32_t buffer_offset
	}, ; 94: Xamarin.AndroidX.ViewPager
	%struct.CompressedAssemblyDescriptor {
		i32 64512, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18341744; uint32_t buffer_offset
	}, ; 95: Xamarin.AndroidX.ViewPager2
	%struct.CompressedAssemblyDescriptor {
		i32 271904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18406256; uint32_t buffer_offset
	}, ; 96: Xamarin.AndroidX.Window
	%struct.CompressedAssemblyDescriptor {
		i32 15904, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18678160; uint32_t buffer_offset
	}, ; 97: Xamarin.AndroidX.Window.WindowCore
	%struct.CompressedAssemblyDescriptor {
		i32 35360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18694064; uint32_t buffer_offset
	}, ; 98: Xamarin.AndroidX.Window.WindowCore.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 2774016, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 18729424; uint32_t buffer_offset
	}, ; 99: Xamarin.Google.Android.Material
	%struct.CompressedAssemblyDescriptor {
		i32 102432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 21503440; uint32_t buffer_offset
	}, ; 100: Jsr305Binding
	%struct.CompressedAssemblyDescriptor {
		i32 5886976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 21605872; uint32_t buffer_offset
	}, ; 101: Xamarin.Google.Crypto.Tink.Android
	%struct.CompressedAssemblyDescriptor {
		i32 101944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27492848; uint32_t buffer_offset
	}, ; 102: Xamarin.Google.ErrorProne.Annotations
	%struct.CompressedAssemblyDescriptor {
		i32 27192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27594792; uint32_t buffer_offset
	}, ; 103: Xamarin.Google.Guava.ListenableFuture
	%struct.CompressedAssemblyDescriptor {
		i32 165944, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27621984; uint32_t buffer_offset
	}, ; 104: Xamarin.Jetbrains.Annotations
	%struct.CompressedAssemblyDescriptor {
		i32 28728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27787928; uint32_t buffer_offset
	}, ; 105: Xamarin.JSpecify
	%struct.CompressedAssemblyDescriptor {
		i32 2375680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 27816656; uint32_t buffer_offset
	}, ; 106: Xamarin.Kotlin.StdLib
	%struct.CompressedAssemblyDescriptor {
		i32 27680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 30192336; uint32_t buffer_offset
	}, ; 107: Xamarin.KotlinX.Coroutines.Android
	%struct.CompressedAssemblyDescriptor {
		i32 16432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 30220016; uint32_t buffer_offset
	}, ; 108: Xamarin.KotlinX.Coroutines.Core
	%struct.CompressedAssemblyDescriptor {
		i32 568880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 30236448; uint32_t buffer_offset
	}, ; 109: Xamarin.KotlinX.Coroutines.Core.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 16416, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 30805328; uint32_t buffer_offset
	}, ; 110: Xamarin.KotlinX.Serialization.Core
	%struct.CompressedAssemblyDescriptor {
		i32 312376, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 30821744; uint32_t buffer_offset
	}, ; 111: Xamarin.KotlinX.Serialization.Core.Jvm
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31134120; uint32_t buffer_offset
	}, ; 112: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31149744; uint32_t buffer_offset
	}, ; 113: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31165376; uint32_t buffer_offset
	}, ; 114: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31181000; uint32_t buffer_offset
	}, ; 115: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31196624; uint32_t buffer_offset
	}, ; 116: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31212256; uint32_t buffer_offset
	}, ; 117: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31227888; uint32_t buffer_offset
	}, ; 118: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31243520; uint32_t buffer_offset
	}, ; 119: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31259144; uint32_t buffer_offset
	}, ; 120: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31274768; uint32_t buffer_offset
	}, ; 121: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31290400; uint32_t buffer_offset
	}, ; 122: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31306024; uint32_t buffer_offset
	}, ; 123: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31321648; uint32_t buffer_offset
	}, ; 124: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31337272; uint32_t buffer_offset
	}, ; 125: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31352896; uint32_t buffer_offset
	}, ; 126: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31368520; uint32_t buffer_offset
	}, ; 127: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31384144; uint32_t buffer_offset
	}, ; 128: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31399768; uint32_t buffer_offset
	}, ; 129: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31415392; uint32_t buffer_offset
	}, ; 130: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31431024; uint32_t buffer_offset
	}, ; 131: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31446688; uint32_t buffer_offset
	}, ; 132: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31462312; uint32_t buffer_offset
	}, ; 133: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31477944; uint32_t buffer_offset
	}, ; 134: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31493576; uint32_t buffer_offset
	}, ; 135: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31509208; uint32_t buffer_offset
	}, ; 136: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31524880; uint32_t buffer_offset
	}, ; 137: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31540512; uint32_t buffer_offset
	}, ; 138: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31556176; uint32_t buffer_offset
	}, ; 139: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31571800; uint32_t buffer_offset
	}, ; 140: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31587424; uint32_t buffer_offset
	}, ; 141: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31603048; uint32_t buffer_offset
	}, ; 142: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15664, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31618672; uint32_t buffer_offset
	}, ; 143: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15624, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31634336; uint32_t buffer_offset
	}, ; 144: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 15632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31649960; uint32_t buffer_offset
	}, ; 145: Microsoft.Maui.Controls.resources
	%struct.CompressedAssemblyDescriptor {
		i32 719360, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 31665592; uint32_t buffer_offset
	}, ; 146: _Microsoft.Android.Resource.Designer
	%struct.CompressedAssemblyDescriptor {
		i32 311632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 32384952; uint32_t buffer_offset
	}, ; 147: Microsoft.CSharp
	%struct.CompressedAssemblyDescriptor {
		i32 428880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 32696584; uint32_t buffer_offset
	}, ; 148: Microsoft.VisualBasic.Core
	%struct.CompressedAssemblyDescriptor {
		i32 17232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33125464; uint32_t buffer_offset
	}, ; 149: Microsoft.VisualBasic
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33142696; uint32_t buffer_offset
	}, ; 150: Microsoft.Win32.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 33104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33158392; uint32_t buffer_offset
	}, ; 151: Microsoft.Win32.Registry
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33191496; uint32_t buffer_offset
	}, ; 152: System.AppContext
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33206680; uint32_t buffer_offset
	}, ; 153: System.Buffers
	%struct.CompressedAssemblyDescriptor {
		i32 88912, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33221864; uint32_t buffer_offset
	}, ; 154: System.Collections.Concurrent
	%struct.CompressedAssemblyDescriptor {
		i32 251216, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33310776; uint32_t buffer_offset
	}, ; 155: System.Collections.Immutable
	%struct.CompressedAssemblyDescriptor {
		i32 47952, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33561992; uint32_t buffer_offset
	}, ; 156: System.Collections.NonGeneric
	%struct.CompressedAssemblyDescriptor {
		i32 47952, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33609944; uint32_t buffer_offset
	}, ; 157: System.Collections.Specialized
	%struct.CompressedAssemblyDescriptor {
		i32 112976, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33657896; uint32_t buffer_offset
	}, ; 158: System.Collections
	%struct.CompressedAssemblyDescriptor {
		i32 102736, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33770872; uint32_t buffer_offset
	}, ; 159: System.ComponentModel.Annotations
	%struct.CompressedAssemblyDescriptor {
		i32 16720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33873608; uint32_t buffer_offset
	}, ; 160: System.ComponentModel.DataAnnotations
	%struct.CompressedAssemblyDescriptor {
		i32 26448, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33890328; uint32_t buffer_offset
	}, ; 161: System.ComponentModel.EventBasedAsync
	%struct.CompressedAssemblyDescriptor {
		i32 42320, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33916776; uint32_t buffer_offset
	}, ; 162: System.ComponentModel.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 316752, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 33959096; uint32_t buffer_offset
	}, ; 163: System.ComponentModel.TypeConverter
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 34275848; uint32_t buffer_offset
	}, ; 164: System.ComponentModel
	%struct.CompressedAssemblyDescriptor {
		i32 19280, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 34292056; uint32_t buffer_offset
	}, ; 165: System.Configuration
	%struct.CompressedAssemblyDescriptor {
		i32 50512, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 34311336; uint32_t buffer_offset
	}, ; 166: System.Console
	%struct.CompressedAssemblyDescriptor {
		i32 23376, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 34361848; uint32_t buffer_offset
	}, ; 167: System.Core
	%struct.CompressedAssemblyDescriptor {
		i32 1018192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 34385224; uint32_t buffer_offset
	}, ; 168: System.Data.Common
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35403416; uint32_t buffer_offset
	}, ; 169: System.Data.DataSetExtensions
	%struct.CompressedAssemblyDescriptor {
		i32 25424, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35419112; uint32_t buffer_offset
	}, ; 170: System.Data
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35444536; uint32_t buffer_offset
	}, ; 171: System.Diagnostics.Contracts
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35460744; uint32_t buffer_offset
	}, ; 172: System.Diagnostics.Debug
	%struct.CompressedAssemblyDescriptor {
		i32 202576, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35476440; uint32_t buffer_offset
	}, ; 173: System.Diagnostics.DiagnosticSource
	%struct.CompressedAssemblyDescriptor {
		i32 29520, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35679016; uint32_t buffer_offset
	}, ; 174: System.Diagnostics.FileVersionInfo
	%struct.CompressedAssemblyDescriptor {
		i32 128848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35708536; uint32_t buffer_offset
	}, ; 175: System.Diagnostics.Process
	%struct.CompressedAssemblyDescriptor {
		i32 25936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35837384; uint32_t buffer_offset
	}, ; 176: System.Diagnostics.StackTrace
	%struct.CompressedAssemblyDescriptor {
		i32 31568, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35863320; uint32_t buffer_offset
	}, ; 177: System.Diagnostics.TextWriterTraceListener
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35894888; uint32_t buffer_offset
	}, ; 178: System.Diagnostics.Tools
	%struct.CompressedAssemblyDescriptor {
		i32 58704, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35910072; uint32_t buffer_offset
	}, ; 179: System.Diagnostics.TraceSource
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35968776; uint32_t buffer_offset
	}, ; 180: System.Diagnostics.Tracing
	%struct.CompressedAssemblyDescriptor {
		i32 64848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 35984984; uint32_t buffer_offset
	}, ; 181: System.Drawing.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 20304, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36049832; uint32_t buffer_offset
	}, ; 182: System.Drawing
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36070136; uint32_t buffer_offset
	}, ; 183: System.Dynamic.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 97104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36086344; uint32_t buffer_offset
	}, ; 184: System.Formats.Asn1
	%struct.CompressedAssemblyDescriptor {
		i32 121680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36183448; uint32_t buffer_offset
	}, ; 185: System.Formats.Tar
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36305128; uint32_t buffer_offset
	}, ; 186: System.Globalization.Calendars
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36320824; uint32_t buffer_offset
	}, ; 187: System.Globalization.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36336008; uint32_t buffer_offset
	}, ; 188: System.Globalization
	%struct.CompressedAssemblyDescriptor {
		i32 41296, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36351704; uint32_t buffer_offset
	}, ; 189: System.IO.Compression.Brotli
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36393000; uint32_t buffer_offset
	}, ; 190: System.IO.Compression.FileSystem
	%struct.CompressedAssemblyDescriptor {
		i32 53584, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36408184; uint32_t buffer_offset
	}, ; 191: System.IO.Compression.ZipFile
	%struct.CompressedAssemblyDescriptor {
		i32 167760, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36461768; uint32_t buffer_offset
	}, ; 192: System.IO.Compression
	%struct.CompressedAssemblyDescriptor {
		i32 32080, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36629528; uint32_t buffer_offset
	}, ; 193: System.IO.FileSystem.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 51536, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36661608; uint32_t buffer_offset
	}, ; 194: System.IO.FileSystem.DriveInfo
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36713144; uint32_t buffer_offset
	}, ; 195: System.IO.FileSystem.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 55120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36728328; uint32_t buffer_offset
	}, ; 196: System.IO.FileSystem.Watcher
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36783448; uint32_t buffer_offset
	}, ; 197: System.IO.FileSystem
	%struct.CompressedAssemblyDescriptor {
		i32 43344, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36799144; uint32_t buffer_offset
	}, ; 198: System.IO.IsolatedStorage
	%struct.CompressedAssemblyDescriptor {
		i32 50000, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36842488; uint32_t buffer_offset
	}, ; 199: System.IO.MemoryMappedFiles
	%struct.CompressedAssemblyDescriptor {
		i32 78160, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36892488; uint32_t buffer_offset
	}, ; 200: System.IO.Pipelines
	%struct.CompressedAssemblyDescriptor {
		i32 23376, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36970648; uint32_t buffer_offset
	}, ; 201: System.IO.Pipes.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 67408, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 36994024; uint32_t buffer_offset
	}, ; 202: System.IO.Pipes
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 37061432; uint32_t buffer_offset
	}, ; 203: System.IO.UnmanagedMemoryStream
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 37077128; uint32_t buffer_offset
	}, ; 204: System.IO
	%struct.CompressedAssemblyDescriptor {
		i32 456528, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 37092824; uint32_t buffer_offset
	}, ; 205: System.Linq.AsyncEnumerable
	%struct.CompressedAssemblyDescriptor {
		i32 575312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 37549352; uint32_t buffer_offset
	}, ; 206: System.Linq.Expressions
	%struct.CompressedAssemblyDescriptor {
		i32 223056, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 38124664; uint32_t buffer_offset
	}, ; 207: System.Linq.Parallel
	%struct.CompressedAssemblyDescriptor {
		i32 78672, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 38347720; uint32_t buffer_offset
	}, ; 208: System.Linq.Queryable
	%struct.CompressedAssemblyDescriptor {
		i32 201040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 38426392; uint32_t buffer_offset
	}, ; 209: System.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 55632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 38627432; uint32_t buffer_offset
	}, ; 210: System.Memory
	%struct.CompressedAssemblyDescriptor {
		i32 56144, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 38683064; uint32_t buffer_offset
	}, ; 211: System.Net.Http.Json
	%struct.CompressedAssemblyDescriptor {
		i32 680272, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 38739208; uint32_t buffer_offset
	}, ; 212: System.Net.Http
	%struct.CompressedAssemblyDescriptor {
		i32 132432, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 39419480; uint32_t buffer_offset
	}, ; 213: System.Net.HttpListener
	%struct.CompressedAssemblyDescriptor {
		i32 174928, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 39551912; uint32_t buffer_offset
	}, ; 214: System.Net.Mail
	%struct.CompressedAssemblyDescriptor {
		i32 52560, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 39726840; uint32_t buffer_offset
	}, ; 215: System.Net.NameResolution
	%struct.CompressedAssemblyDescriptor {
		i32 66384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 39779400; uint32_t buffer_offset
	}, ; 216: System.Net.NetworkInformation
	%struct.CompressedAssemblyDescriptor {
		i32 55632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 39845784; uint32_t buffer_offset
	}, ; 217: System.Net.Ping
	%struct.CompressedAssemblyDescriptor {
		i32 108880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 39901416; uint32_t buffer_offset
	}, ; 218: System.Net.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 171856, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40010296; uint32_t buffer_offset
	}, ; 219: System.Net.Quic
	%struct.CompressedAssemblyDescriptor {
		i32 161616, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40182152; uint32_t buffer_offset
	}, ; 220: System.Net.Requests
	%struct.CompressedAssemblyDescriptor {
		i32 255312, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40343768; uint32_t buffer_offset
	}, ; 221: System.Net.Security
	%struct.CompressedAssemblyDescriptor {
		i32 40784, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40599080; uint32_t buffer_offset
	}, ; 222: System.Net.ServerSentEvents
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40639864; uint32_t buffer_offset
	}, ; 223: System.Net.ServicePoint
	%struct.CompressedAssemblyDescriptor {
		i32 238416, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40655048; uint32_t buffer_offset
	}, ; 224: System.Net.Sockets
	%struct.CompressedAssemblyDescriptor {
		i32 70480, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40893464; uint32_t buffer_offset
	}, ; 225: System.Net.WebClient
	%struct.CompressedAssemblyDescriptor {
		i32 33104, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40963944; uint32_t buffer_offset
	}, ; 226: System.Net.WebHeaderCollection
	%struct.CompressedAssemblyDescriptor {
		i32 23376, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 40997048; uint32_t buffer_offset
	}, ; 227: System.Net.WebProxy
	%struct.CompressedAssemblyDescriptor {
		i32 51536, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41020424; uint32_t buffer_offset
	}, ; 228: System.Net.WebSockets.Client
	%struct.CompressedAssemblyDescriptor {
		i32 108880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41071960; uint32_t buffer_offset
	}, ; 229: System.Net.WebSockets
	%struct.CompressedAssemblyDescriptor {
		i32 17232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41180840; uint32_t buffer_offset
	}, ; 230: System.Net
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41198072; uint32_t buffer_offset
	}, ; 231: System.Numerics.Vectors
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41213768; uint32_t buffer_offset
	}, ; 232: System.Numerics
	%struct.CompressedAssemblyDescriptor {
		i32 41296, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41228952; uint32_t buffer_offset
	}, ; 233: System.ObjectModel
	%struct.CompressedAssemblyDescriptor {
		i32 859472, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 41270248; uint32_t buffer_offset
	}, ; 234: System.Private.DataContractSerialization
	%struct.CompressedAssemblyDescriptor {
		i32 105808, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 42129720; uint32_t buffer_offset
	}, ; 235: System.Private.Uri
	%struct.CompressedAssemblyDescriptor {
		i32 153936, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 42235528; uint32_t buffer_offset
	}, ; 236: System.Private.Xml.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 3106128, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 42389464; uint32_t buffer_offset
	}, ; 237: System.Private.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 38224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 45495592; uint32_t buffer_offset
	}, ; 238: System.Reflection.DispatchProxy
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 45533816; uint32_t buffer_offset
	}, ; 239: System.Reflection.Emit.ILGeneration
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 45549512; uint32_t buffer_offset
	}, ; 240: System.Reflection.Emit.Lightweight
	%struct.CompressedAssemblyDescriptor {
		i32 133456, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 45565208; uint32_t buffer_offset
	}, ; 241: System.Reflection.Emit
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 45698664; uint32_t buffer_offset
	}, ; 242: System.Reflection.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 503632, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 45713848; uint32_t buffer_offset
	}, ; 243: System.Reflection.Metadata
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46217480; uint32_t buffer_offset
	}, ; 244: System.Reflection.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 24400, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46233176; uint32_t buffer_offset
	}, ; 245: System.Reflection.TypeExtensions
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46257576; uint32_t buffer_offset
	}, ; 246: System.Reflection
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46273784; uint32_t buffer_offset
	}, ; 247: System.Resources.Reader
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46288968; uint32_t buffer_offset
	}, ; 248: System.Resources.ResourceManager
	%struct.CompressedAssemblyDescriptor {
		i32 26960, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46304664; uint32_t buffer_offset
	}, ; 249: System.Resources.Writer
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46331624; uint32_t buffer_offset
	}, ; 250: System.Runtime.CompilerServices.Unsafe
	%struct.CompressedAssemblyDescriptor {
		i32 17232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46346808; uint32_t buffer_offset
	}, ; 251: System.Runtime.CompilerServices.VisualC
	%struct.CompressedAssemblyDescriptor {
		i32 17744, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46364040; uint32_t buffer_offset
	}, ; 252: System.Runtime.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46381784; uint32_t buffer_offset
	}, ; 253: System.Runtime.Handles
	%struct.CompressedAssemblyDescriptor {
		i32 38224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46397480; uint32_t buffer_offset
	}, ; 254: System.Runtime.InteropServices.JavaScript
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46435704; uint32_t buffer_offset
	}, ; 255: System.Runtime.InteropServices.RuntimeInformation
	%struct.CompressedAssemblyDescriptor {
		i32 64848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46450888; uint32_t buffer_offset
	}, ; 256: System.Runtime.InteropServices
	%struct.CompressedAssemblyDescriptor {
		i32 17232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46515736; uint32_t buffer_offset
	}, ; 257: System.Runtime.Intrinsics
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46532968; uint32_t buffer_offset
	}, ; 258: System.Runtime.Loader
	%struct.CompressedAssemblyDescriptor {
		i32 145232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46548664; uint32_t buffer_offset
	}, ; 259: System.Runtime.Numerics
	%struct.CompressedAssemblyDescriptor {
		i32 65872, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46693896; uint32_t buffer_offset
	}, ; 260: System.Runtime.Serialization.Formatters
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46759768; uint32_t buffer_offset
	}, ; 261: System.Runtime.Serialization.Json
	%struct.CompressedAssemblyDescriptor {
		i32 23376, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46775464; uint32_t buffer_offset
	}, ; 262: System.Runtime.Serialization.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 16720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46798840; uint32_t buffer_offset
	}, ; 263: System.Runtime.Serialization.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 17232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46815560; uint32_t buffer_offset
	}, ; 264: System.Runtime.Serialization
	%struct.CompressedAssemblyDescriptor {
		i32 44880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46832792; uint32_t buffer_offset
	}, ; 265: System.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 58192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46877672; uint32_t buffer_offset
	}, ; 266: System.Security.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 55120, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46935864; uint32_t buffer_offset
	}, ; 267: System.Security.Claims
	%struct.CompressedAssemblyDescriptor {
		i32 17232, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 46990984; uint32_t buffer_offset
	}, ; 268: System.Security.Cryptography.Algorithms
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47008216; uint32_t buffer_offset
	}, ; 269: System.Security.Cryptography.Cng
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47024424; uint32_t buffer_offset
	}, ; 270: System.Security.Cryptography.Csp
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47040632; uint32_t buffer_offset
	}, ; 271: System.Security.Cryptography.Encoding
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47056328; uint32_t buffer_offset
	}, ; 272: System.Security.Cryptography.OpenSsl
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47072024; uint32_t buffer_offset
	}, ; 273: System.Security.Cryptography.Primitives
	%struct.CompressedAssemblyDescriptor {
		i32 16720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47087720; uint32_t buffer_offset
	}, ; 274: System.Security.Cryptography.X509Certificates
	%struct.CompressedAssemblyDescriptor {
		i32 852816, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47104440; uint32_t buffer_offset
	}, ; 275: System.Security.Cryptography
	%struct.CompressedAssemblyDescriptor {
		i32 37712, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47957256; uint32_t buffer_offset
	}, ; 276: System.Security.Principal.Windows
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 47994968; uint32_t buffer_offset
	}, ; 277: System.Security.Principal
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48010152; uint32_t buffer_offset
	}, ; 278: System.Security.SecureString
	%struct.CompressedAssemblyDescriptor {
		i32 18256, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48025848; uint32_t buffer_offset
	}, ; 279: System.Security
	%struct.CompressedAssemblyDescriptor {
		i32 16720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48044104; uint32_t buffer_offset
	}, ; 280: System.ServiceModel.Web
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48060824; uint32_t buffer_offset
	}, ; 281: System.ServiceProcess
	%struct.CompressedAssemblyDescriptor {
		i32 742736, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48076520; uint32_t buffer_offset
	}, ; 282: System.Text.Encoding.CodePages
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48819256; uint32_t buffer_offset
	}, ; 283: System.Text.Encoding.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48834952; uint32_t buffer_offset
	}, ; 284: System.Text.Encoding
	%struct.CompressedAssemblyDescriptor {
		i32 65872, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48850648; uint32_t buffer_offset
	}, ; 285: System.Text.Encodings.Web
	%struct.CompressedAssemblyDescriptor {
		i32 649040, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 48916520; uint32_t buffer_offset
	}, ; 286: System.Text.Json
	%struct.CompressedAssemblyDescriptor {
		i32 384848, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 49565560; uint32_t buffer_offset
	}, ; 287: System.Text.RegularExpressions
	%struct.CompressedAssemblyDescriptor {
		i32 33616, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 49950408; uint32_t buffer_offset
	}, ; 288: System.Threading.AccessControl
	%struct.CompressedAssemblyDescriptor {
		i32 66384, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 49984024; uint32_t buffer_offset
	}, ; 289: System.Threading.Channels
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50050408; uint32_t buffer_offset
	}, ; 290: System.Threading.Overlapped
	%struct.CompressedAssemblyDescriptor {
		i32 185680, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50066104; uint32_t buffer_offset
	}, ; 291: System.Threading.Tasks.Dataflow
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50251784; uint32_t buffer_offset
	}, ; 292: System.Threading.Tasks.Extensions
	%struct.CompressedAssemblyDescriptor {
		i32 61264, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50267480; uint32_t buffer_offset
	}, ; 293: System.Threading.Tasks.Parallel
	%struct.CompressedAssemblyDescriptor {
		i32 16720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50328744; uint32_t buffer_offset
	}, ; 294: System.Threading.Tasks
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50345464; uint32_t buffer_offset
	}, ; 295: System.Threading.Thread
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50361160; uint32_t buffer_offset
	}, ; 296: System.Threading.ThreadPool
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50376856; uint32_t buffer_offset
	}, ; 297: System.Threading.Timer
	%struct.CompressedAssemblyDescriptor {
		i32 44880, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50392040; uint32_t buffer_offset
	}, ; 298: System.Threading
	%struct.CompressedAssemblyDescriptor {
		i32 175952, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50436920; uint32_t buffer_offset
	}, ; 299: System.Transactions.Local
	%struct.CompressedAssemblyDescriptor {
		i32 16720, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50612872; uint32_t buffer_offset
	}, ; 300: System.Transactions
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50629592; uint32_t buffer_offset
	}, ; 301: System.ValueTuple
	%struct.CompressedAssemblyDescriptor {
		i32 30032, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50645288; uint32_t buffer_offset
	}, ; 302: System.Web.HttpUtility
	%struct.CompressedAssemblyDescriptor {
		i32 15184, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50675320; uint32_t buffer_offset
	}, ; 303: System.Web
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50690504; uint32_t buffer_offset
	}, ; 304: System.Windows
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50706200; uint32_t buffer_offset
	}, ; 305: System.Xml.Linq
	%struct.CompressedAssemblyDescriptor {
		i32 21840, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50721896; uint32_t buffer_offset
	}, ; 306: System.Xml.ReaderWriter
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50743736; uint32_t buffer_offset
	}, ; 307: System.Xml.Serialization
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50759944; uint32_t buffer_offset
	}, ; 308: System.Xml.XDocument
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50775640; uint32_t buffer_offset
	}, ; 309: System.Xml.XPath.XDocument
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50791336; uint32_t buffer_offset
	}, ; 310: System.Xml.XPath
	%struct.CompressedAssemblyDescriptor {
		i32 15696, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50807032; uint32_t buffer_offset
	}, ; 311: System.Xml.XmlDocument
	%struct.CompressedAssemblyDescriptor {
		i32 17744, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50822728; uint32_t buffer_offset
	}, ; 312: System.Xml.XmlSerializer
	%struct.CompressedAssemblyDescriptor {
		i32 23376, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50840472; uint32_t buffer_offset
	}, ; 313: System.Xml
	%struct.CompressedAssemblyDescriptor {
		i32 50512, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50863848; uint32_t buffer_offset
	}, ; 314: System
	%struct.CompressedAssemblyDescriptor {
		i32 16208, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50914360; uint32_t buffer_offset
	}, ; 315: WindowsBase
	%struct.CompressedAssemblyDescriptor {
		i32 59728, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50930568; uint32_t buffer_offset
	}, ; 316: mscorlib
	%struct.CompressedAssemblyDescriptor {
		i32 100688, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 50990296; uint32_t buffer_offset
	}, ; 317: netstandard
	%struct.CompressedAssemblyDescriptor {
		i32 244576, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 51090984; uint32_t buffer_offset
	}, ; 318: Java.Interop
	%struct.CompressedAssemblyDescriptor {
		i32 83296, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 51335560; uint32_t buffer_offset
	}, ; 319: Mono.Android.Export
	%struct.CompressedAssemblyDescriptor {
		i32 22368, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 51418856; uint32_t buffer_offset
	}, ; 320: Mono.Android.Runtime
	%struct.CompressedAssemblyDescriptor {
		i32 41460224, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 51441224; uint32_t buffer_offset
	}, ; 321: Mono.Android
	%struct.CompressedAssemblyDescriptor {
		i32 55648, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 92901448; uint32_t buffer_offset
	}, ; 322: System.IO.Hashing
	%struct.CompressedAssemblyDescriptor {
		i32 4922192, ; uint32_t uncompressed_file_size
		i1 false, ; bool loaded
		i32 92957096; uint32_t buffer_offset
	} ; 323: System.Private.CoreLib
], align 4

@uncompressed_assemblies_data_size = dso_local local_unnamed_addr constant i32 97879288, align 4

@uncompressed_assemblies_data_buffer = dso_local local_unnamed_addr global [97879288 x i8] zeroinitializer, align 1

; Metadata
!llvm.module.flags = !{!0, !1, !7}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!llvm.ident = !{!2}
!2 = !{!".NET for Android remotes/origin/release/10.0.1xx @ d549e1dc4e2a083b08b4f24cb5495e81b99d79b5"}
!3 = !{!4, !4, i64 0}
!4 = !{!"any pointer", !5, i64 0}
!5 = !{!"omnipotent char", !6, i64 0}
!6 = !{!"Simple C++ TBAA"}
!7 = !{i32 1, !"min_enum_size", i32 4}
