; ModuleID = 'obj/Debug/android/marshal_methods.armeabi-v7a.ll'
source_filename = "obj/Debug/android/marshal_methods.armeabi-v7a.ll"
target datalayout = "e-m:e-p:32:32-Fi8-i64:64-v128:64:128-a:0:32-n32-S64"
target triple = "armv7-unknown-linux-android"


%struct.MonoImage = type opaque

%struct.MonoClass = type opaque

%struct.MarshalMethodsManagedClass = type {
	i32,; uint32_t token
	%struct.MonoClass*; MonoClass* klass
}

%struct.MarshalMethodName = type {
	i64,; uint64_t id
	i8*; char* name
}

%class._JNIEnv = type opaque

%class._jobject = type {
	i8; uint8_t b
}

%class._jclass = type {
	i8; uint8_t b
}

%class._jstring = type {
	i8; uint8_t b
}

%class._jthrowable = type {
	i8; uint8_t b
}

%class._jarray = type {
	i8; uint8_t b
}

%class._jobjectArray = type {
	i8; uint8_t b
}

%class._jbooleanArray = type {
	i8; uint8_t b
}

%class._jbyteArray = type {
	i8; uint8_t b
}

%class._jcharArray = type {
	i8; uint8_t b
}

%class._jshortArray = type {
	i8; uint8_t b
}

%class._jintArray = type {
	i8; uint8_t b
}

%class._jlongArray = type {
	i8; uint8_t b
}

%class._jfloatArray = type {
	i8; uint8_t b
}

%class._jdoubleArray = type {
	i8; uint8_t b
}

; assembly_image_cache
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 4
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [282 x i32] [
	i32 32687329, ; 0: Xamarin.AndroidX.Lifecycle.Runtime => 0x1f2c4e1 => 88
	i32 34715100, ; 1: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 121
	i32 39109920, ; 2: Newtonsoft.Json.dll => 0x254c520 => 11
	i32 39852199, ; 3: Plugin.Permissions => 0x26018a7 => 17
	i32 57263871, ; 4: Xamarin.Forms.Core.dll => 0x369c6ff => 113
	i32 57967248, ; 5: Xamarin.Android.Support.VersionedParcelable.dll => 0x3748290 => 57
	i32 101534019, ; 6: Xamarin.AndroidX.SlidingPaneLayout => 0x60d4943 => 102
	i32 120558881, ; 7: Xamarin.AndroidX.SlidingPaneLayout.dll => 0x72f9521 => 102
	i32 160529393, ; 8: Xamarin.Android.Arch.Core.Common => 0x9917bf1 => 30
	i32 165246403, ; 9: Xamarin.AndroidX.Collection.dll => 0x9d975c3 => 69
	i32 166922606, ; 10: Xamarin.Android.Support.Compat.dll => 0x9f3096e => 40
	i32 182336117, ; 11: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 103
	i32 201930040, ; 12: Xamarin.Android.Arch.Core.Runtime => 0xc093538 => 31
	i32 209399409, ; 13: Xamarin.AndroidX.Browser.dll => 0xc7b2e71 => 67
	i32 212497893, ; 14: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 114
	i32 219130465, ; 15: Xamarin.Android.Support.v4 => 0xd0faa61 => 56
	i32 230216969, ; 16: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0xdb8d509 => 83
	i32 232815796, ; 17: System.Web.Services => 0xde07cb4 => 137
	i32 261689757, ; 18: Xamarin.AndroidX.ConstraintLayout.dll => 0xf99119d => 72
	i32 278686392, ; 19: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x109c6ab8 => 87
	i32 280482487, ; 20: Xamarin.AndroidX.Interpolator => 0x10b7d2b7 => 81
	i32 318968648, ; 21: Xamarin.AndroidX.Activity.dll => 0x13031348 => 59
	i32 319314094, ; 22: Xamarin.Forms.Maps => 0x130858ae => 115
	i32 321597661, ; 23: System.Numerics => 0x132b30dd => 24
	i32 323373387, ; 24: WeCharge.dll => 0x1346494b => 29
	i32 342366114, ; 25: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 85
	i32 389971796, ; 26: Xamarin.Android.Support.Core.UI => 0x173e7f54 => 42
	i32 441335492, ; 27: Xamarin.AndroidX.ConstraintLayout.Core => 0x1a4e3ec4 => 71
	i32 442521989, ; 28: Xamarin.Essentials => 0x1a605985 => 112
	i32 450948140, ; 29: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 80
	i32 465846621, ; 30: mscorlib => 0x1bc4415d => 10
	i32 469710990, ; 31: System.dll => 0x1bff388e => 23
	i32 476646585, ; 32: Xamarin.AndroidX.Interpolator.dll => 0x1c690cb9 => 81
	i32 486930444, ; 33: Xamarin.AndroidX.LocalBroadcastManager.dll => 0x1d05f80c => 92
	i32 501699973, ; 34: Xamarin.Forms.Skeleton => 0x1de75585 => 118
	i32 514659665, ; 35: Xamarin.Android.Support.Compat => 0x1ead1551 => 40
	i32 524864063, ; 36: Xamarin.Android.Support.Print => 0x1f48ca3f => 53
	i32 525008092, ; 37: SkiaSharp.dll => 0x1f4afcdc => 19
	i32 526420162, ; 38: System.Transactions.dll => 0x1f6088c2 => 131
	i32 605376203, ; 39: System.IO.Compression.FileSystem => 0x24154ecb => 135
	i32 627609679, ; 40: Xamarin.AndroidX.CustomView => 0x2568904f => 76
	i32 663517072, ; 41: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 108
	i32 666292255, ; 42: Xamarin.AndroidX.Arch.Core.Common.dll => 0x27b6d01f => 64
	i32 679820142, ; 43: Plugin.Connectivity.Abstractions => 0x28853b6e => 12
	i32 690569205, ; 44: System.Xml.Linq.dll => 0x29293ff5 => 28
	i32 692692150, ; 45: Xamarin.Android.Support.Annotations => 0x2949a4b6 => 37
	i32 747088582, ; 46: Xamarin.Forms.Skeleton.dll => 0x2c87aac6 => 118
	i32 775507847, ; 47: System.IO.Compression => 0x2e394f87 => 134
	i32 801787702, ; 48: Xamarin.Android.Support.Interpolator => 0x2fca4f36 => 49
	i32 809851609, ; 49: System.Drawing.Common.dll => 0x30455ad9 => 133
	i32 843511501, ; 50: Xamarin.AndroidX.Print => 0x3246f6cd => 99
	i32 882883187, ; 51: Xamarin.Android.Support.v4.dll => 0x349fba73 => 56
	i32 886248193, ; 52: Microcharts.Droid => 0x34d31301 => 7
	i32 902159924, ; 53: Rg.Plugins.Popup => 0x35c5de34 => 18
	i32 916714535, ; 54: Xamarin.Android.Support.Print.dll => 0x36a3f427 => 53
	i32 928116545, ; 55: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 121
	i32 955402788, ; 56: Newtonsoft.Json => 0x38f24a24 => 11
	i32 957807352, ; 57: Plugin.CurrentActivity => 0x3916faf8 => 14
	i32 958213972, ; 58: Xamarin.Android.Support.Media.Compat => 0x391d2f54 => 52
	i32 967690846, ; 59: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 85
	i32 974778368, ; 60: FormsViewGroup.dll => 0x3a19f000 => 4
	i32 987342438, ; 61: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0x3ad9a666 => 34
	i32 991232677, ; 62: WeCharge => 0x3b1502a5 => 29
	i32 1012816738, ; 63: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 101
	i32 1035644815, ; 64: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 63
	i32 1042160112, ; 65: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 117
	i32 1052210849, ; 66: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 89
	i32 1098167829, ; 67: Xamarin.Android.Arch.Lifecycle.ViewModel => 0x4174b615 => 36
	i32 1098259244, ; 68: System => 0x41761b2c => 23
	i32 1137654822, ; 69: Plugin.Permissions.dll => 0x43cf3c26 => 17
	i32 1175144683, ; 70: Xamarin.AndroidX.VectorDrawable.Animated => 0x460b48eb => 106
	i32 1178241025, ; 71: Xamarin.AndroidX.Navigation.Runtime.dll => 0x463a8801 => 96
	i32 1204270330, ; 72: Xamarin.AndroidX.Arch.Core.Common => 0x47c7b4fa => 64
	i32 1267360935, ; 73: Xamarin.AndroidX.VectorDrawable => 0x4b8a64a7 => 107
	i32 1282958517, ; 74: Plugin.Geolocator => 0x4c7864b5 => 16
	i32 1292763917, ; 75: Xamarin.Android.Support.CursorAdapter.dll => 0x4d0e030d => 44
	i32 1293217323, ; 76: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 78
	i32 1297413738, ; 77: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0x4d54f66a => 33
	i32 1365406463, ; 78: System.ServiceModel.Internals.dll => 0x516272ff => 128
	i32 1376866003, ; 79: Xamarin.AndroidX.SavedState => 0x52114ed3 => 101
	i32 1395857551, ; 80: Xamarin.AndroidX.Media.dll => 0x5333188f => 93
	i32 1406073936, ; 81: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 73
	i32 1409799710, ; 82: com.refractored.monodroidtoolkit.dll => 0x5407d61e => 3
	i32 1445445088, ; 83: Xamarin.Android.Support.Fragment => 0x5627bde0 => 48
	i32 1460219004, ; 84: Xamarin.Forms.Xaml => 0x57092c7c => 119
	i32 1462112819, ; 85: System.IO.Compression.dll => 0x57261233 => 134
	i32 1469204771, ; 86: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 62
	i32 1530663695, ; 87: Xamarin.Forms.Maps.dll => 0x5b3c130f => 115
	i32 1574652163, ; 88: Xamarin.Android.Support.Core.Utils.dll => 0x5ddb4903 => 43
	i32 1582372066, ; 89: Xamarin.AndroidX.DocumentFile.dll => 0x5e5114e2 => 77
	i32 1582526884, ; 90: Microcharts.Forms.dll => 0x5e5371a4 => 8
	i32 1587447679, ; 91: Xamarin.Android.Arch.Core.Common.dll => 0x5e9e877f => 30
	i32 1592978981, ; 92: System.Runtime.Serialization.dll => 0x5ef2ee25 => 2
	i32 1599218041, ; 93: WeCharge.Android => 0x5f522179 => 0
	i32 1622152042, ; 94: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 91
	i32 1624863272, ; 95: Xamarin.AndroidX.ViewPager2 => 0x60d97228 => 110
	i32 1636350590, ; 96: Xamarin.AndroidX.CursorAdapter => 0x6188ba7e => 75
	i32 1639515021, ; 97: System.Net.Http.dll => 0x61b9038d => 1
	i32 1657153582, ; 98: System.Runtime => 0x62c6282e => 26
	i32 1658241508, ; 99: Xamarin.AndroidX.Tracing.Tracing.dll => 0x62d6c1e4 => 104
	i32 1658251792, ; 100: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 120
	i32 1670060433, ; 101: Xamarin.AndroidX.ConstraintLayout => 0x638b1991 => 72
	i32 1722051300, ; 102: SkiaSharp.Views.Forms => 0x66a46ae4 => 21
	i32 1729485958, ; 103: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 68
	i32 1732094681, ; 104: Plugin.Geofence.dll => 0x673daad9 => 15
	i32 1766324549, ; 105: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 103
	i32 1776026572, ; 106: System.Core.dll => 0x69dc03cc => 22
	i32 1788241197, ; 107: Xamarin.AndroidX.Fragment => 0x6a96652d => 80
	i32 1808609942, ; 108: Xamarin.AndroidX.Loader => 0x6bcd3296 => 91
	i32 1813201214, ; 109: Xamarin.Google.Android.Material => 0x6c13413e => 120
	i32 1818569960, ; 110: Xamarin.AndroidX.Navigation.UI.dll => 0x6c652ce8 => 97
	i32 1861194840, ; 111: Plugin.Geofence => 0x6eef9458 => 15
	i32 1866717392, ; 112: Xamarin.Android.Support.Interpolator.dll => 0x6f43d8d0 => 49
	i32 1867746548, ; 113: Xamarin.Essentials.dll => 0x6f538cf4 => 112
	i32 1878053835, ; 114: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 119
	i32 1881862856, ; 115: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 114
	i32 1885316902, ; 116: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0x705fa726 => 65
	i32 1908813208, ; 117: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 123
	i32 1916660109, ; 118: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x723de98d => 36
	i32 1919157823, ; 119: Xamarin.AndroidX.MultiDex.dll => 0x7264063f => 94
	i32 2019465201, ; 120: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 89
	i32 2037417872, ; 121: Xamarin.Android.Support.ViewPager => 0x79708790 => 58
	i32 2044222327, ; 122: Xamarin.Android.Support.Loader => 0x79d85b77 => 50
	i32 2055257422, ; 123: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 86
	i32 2079903147, ; 124: System.Runtime.dll => 0x7bf8cdab => 26
	i32 2090596640, ; 125: System.Numerics.Vectors => 0x7c9bf920 => 25
	i32 2097448633, ; 126: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 82
	i32 2126786730, ; 127: Xamarin.Forms.Platform.Android => 0x7ec430aa => 116
	i32 2129483829, ; 128: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 122
	i32 2139458754, ; 129: Xamarin.Android.Support.DrawerLayout => 0x7f858cc2 => 47
	i32 2166116741, ; 130: Xamarin.Android.Support.Core.Utils => 0x811c5185 => 43
	i32 2196165013, ; 131: Xamarin.Android.Support.VersionedParcelable => 0x82e6d195 => 57
	i32 2201231467, ; 132: System.Net.Http => 0x8334206b => 1
	i32 2217644978, ; 133: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x842e93b2 => 106
	i32 2244775296, ; 134: Xamarin.AndroidX.LocalBroadcastManager => 0x85cc8d80 => 92
	i32 2256548716, ; 135: Xamarin.AndroidX.MultiDex => 0x8680336c => 94
	i32 2261435625, ; 136: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x86cac4e9 => 84
	i32 2279755925, ; 137: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 100
	i32 2315684594, ; 138: Xamarin.AndroidX.Annotation.dll => 0x8a068af2 => 60
	i32 2330457430, ; 139: Xamarin.Android.Support.Core.UI.dll => 0x8ae7f556 => 42
	i32 2330986192, ; 140: Xamarin.Android.Support.SlidingPaneLayout.dll => 0x8af006d0 => 54
	i32 2373288475, ; 141: Xamarin.Android.Support.Fragment.dll => 0x8d75821b => 48
	i32 2409053734, ; 142: Xamarin.AndroidX.Preference.dll => 0x8f973e26 => 98
	i32 2440966767, ; 143: Xamarin.Android.Support.Loader.dll => 0x917e326f => 50
	i32 2465532216, ; 144: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x92f50938 => 71
	i32 2471841756, ; 145: netstandard.dll => 0x93554fdc => 129
	i32 2475788418, ; 146: Java.Interop.dll => 0x93918882 => 5
	i32 2487632829, ; 147: Xamarin.Android.Support.DocumentFile => 0x944643bd => 46
	i32 2501346920, ; 148: System.Data.DataSetExtensions => 0x95178668 => 132
	i32 2505896520, ; 149: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x955cf248 => 88
	i32 2581819634, ; 150: Xamarin.AndroidX.VectorDrawable.dll => 0x99e370f2 => 107
	i32 2620871830, ; 151: Xamarin.AndroidX.CursorAdapter.dll => 0x9c375496 => 75
	i32 2624644809, ; 152: Xamarin.AndroidX.DynamicAnimation => 0x9c70e6c9 => 79
	i32 2633051222, ; 153: Xamarin.AndroidX.Lifecycle.LiveData => 0x9cf12c56 => 87
	i32 2635085952, ; 154: WeCharge.Android.dll => 0x9d103880 => 0
	i32 2698266930, ; 155: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa0d44932 => 34
	i32 2701096212, ; 156: Xamarin.AndroidX.Tracing.Tracing => 0xa0ff7514 => 104
	i32 2715334215, ; 157: System.Threading.Tasks.dll => 0xa1d8b647 => 138
	i32 2728372006, ; 158: com.refractored.monodroidtoolkit => 0xa29fa726 => 3
	i32 2732626843, ; 159: Xamarin.AndroidX.Activity => 0xa2e0939b => 59
	i32 2737747696, ; 160: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 62
	i32 2751899777, ; 161: Xamarin.Android.Support.Collections => 0xa406a881 => 39
	i32 2766581644, ; 162: Xamarin.Forms.Core => 0xa4e6af8c => 113
	i32 2778768386, ; 163: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 109
	i32 2788639665, ; 164: Xamarin.Android.Support.LocalBroadcastManager => 0xa63743b1 => 51
	i32 2788775637, ; 165: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0xa63956d5 => 55
	i32 2795602088, ; 166: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 20
	i32 2806986428, ; 167: Plugin.CurrentActivity.dll => 0xa74f36bc => 14
	i32 2810250172, ; 168: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 73
	i32 2819470561, ; 169: System.Xml.dll => 0xa80db4e1 => 27
	i32 2847418871, ; 170: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 122
	i32 2853208004, ; 171: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 109
	i32 2855708567, ; 172: Xamarin.AndroidX.Transition => 0xaa36a797 => 105
	i32 2861816565, ; 173: Rg.Plugins.Popup.dll => 0xaa93daf5 => 18
	i32 2876493027, ; 174: Xamarin.Android.Support.SwipeRefreshLayout => 0xab73cce3 => 55
	i32 2893257763, ; 175: Xamarin.Android.Arch.Core.Runtime.dll => 0xac739c23 => 31
	i32 2903344695, ; 176: System.ComponentModel.Composition => 0xad0d8637 => 136
	i32 2905242038, ; 177: mscorlib.dll => 0xad2a79b6 => 10
	i32 2912489636, ; 178: SkiaSharp.Views.Android => 0xad9910a4 => 20
	i32 2916838712, ; 179: Xamarin.AndroidX.ViewPager2.dll => 0xaddb6d38 => 110
	i32 2919462931, ; 180: System.Numerics.Vectors.dll => 0xae037813 => 25
	i32 2921128767, ; 181: Xamarin.AndroidX.Annotation.Experimental.dll => 0xae1ce33f => 61
	i32 2921692953, ; 182: Xamarin.Android.Support.CustomView.dll => 0xae257f19 => 45
	i32 2957587826, ; 183: Xamarin.GooglePlayServices.Places.PlaceReport.dll => 0xb0493572 => 126
	i32 2974793899, ; 184: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 21
	i32 2978675010, ; 185: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 78
	i32 3017076677, ; 186: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 125
	i32 3024354802, ; 187: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xb443fdf2 => 83
	i32 3036068679, ; 188: Microcharts.Droid.dll => 0xb4f6bb47 => 7
	i32 3044182254, ; 189: FormsViewGroup => 0xb57288ee => 4
	i32 3056250942, ; 190: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0xb62ab03e => 38
	i32 3057625584, ; 191: Xamarin.AndroidX.Navigation.Common => 0xb63fa9f0 => 95
	i32 3058099980, ; 192: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 127
	i32 3068715062, ; 193: Xamarin.Android.Arch.Lifecycle.Common => 0xb6e8e036 => 32
	i32 3075834255, ; 194: System.Threading.Tasks => 0xb755818f => 138
	i32 3092211740, ; 195: Xamarin.Android.Support.Media.Compat.dll => 0xb84f681c => 52
	i32 3111772706, ; 196: System.Runtime.Serialization => 0xb979e222 => 2
	i32 3126016514, ; 197: Plugin.Geolocator.dll => 0xba533a02 => 16
	i32 3204380047, ; 198: System.Data.dll => 0xbefef58f => 130
	i32 3204912593, ; 199: Xamarin.Android.Support.AsyncLayoutInflater => 0xbf0715d1 => 38
	i32 3211777861, ; 200: Xamarin.AndroidX.DocumentFile => 0xbf6fd745 => 77
	i32 3220365878, ; 201: System.Threading => 0xbff2e236 => 139
	i32 3230466174, ; 202: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 123
	i32 3233339011, ; 203: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xc0b8d683 => 33
	i32 3247949154, ; 204: Mono.Security => 0xc197c562 => 140
	i32 3258312781, ; 205: Xamarin.AndroidX.CardView => 0xc235e84d => 68
	i32 3267021929, ; 206: Xamarin.AndroidX.AsyncLayoutInflater => 0xc2bacc69 => 66
	i32 3296380511, ; 207: Xamarin.Android.Support.Collections.dll => 0xc47ac65f => 39
	i32 3317135071, ; 208: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 76
	i32 3317144872, ; 209: System.Data => 0xc5b79d28 => 130
	i32 3321585405, ; 210: Xamarin.Android.Support.DocumentFile.dll => 0xc5fb5efd => 46
	i32 3340387945, ; 211: SkiaSharp => 0xc71a4669 => 19
	i32 3340431453, ; 212: Xamarin.AndroidX.Arch.Core.Runtime => 0xc71af05d => 65
	i32 3342024700, ; 213: Plugin.Connectivity.Abstractions.dll => 0xc7333ffc => 12
	i32 3346324047, ; 214: Xamarin.AndroidX.Navigation.Runtime => 0xc774da4f => 96
	i32 3352662376, ; 215: Xamarin.Android.Support.CoordinaterLayout => 0xc7d59168 => 41
	i32 3353484488, ; 216: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 82
	i32 3353544232, ; 217: Xamarin.CommunityToolkit.dll => 0xc7e30628 => 111
	i32 3357663996, ; 218: Xamarin.Android.Support.CursorAdapter => 0xc821e2fc => 44
	i32 3362522851, ; 219: Xamarin.AndroidX.Core => 0xc86c06e3 => 74
	i32 3366046733, ; 220: Plugin.Connectivity.dll => 0xc8a1cc0d => 13
	i32 3366347497, ; 221: Java.Interop => 0xc8a662e9 => 5
	i32 3374999561, ; 222: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 100
	i32 3404865022, ; 223: System.ServiceModel.Internals => 0xcaf21dfe => 128
	i32 3407215217, ; 224: Xamarin.CommunityToolkit => 0xcb15fa71 => 111
	i32 3429136800, ; 225: System.Xml => 0xcc6479a0 => 27
	i32 3430777524, ; 226: netstandard => 0xcc7d82b4 => 129
	i32 3439690031, ; 227: Xamarin.Android.Support.Annotations.dll => 0xcd05812f => 37
	i32 3441283291, ; 228: Xamarin.AndroidX.DynamicAnimation.dll => 0xcd1dd0db => 79
	i32 3455791806, ; 229: Microcharts => 0xcdfb32be => 6
	i32 3476120550, ; 230: Mono.Android => 0xcf3163e6 => 9
	i32 3486566296, ; 231: System.Transactions => 0xcfd0c798 => 131
	i32 3493954962, ; 232: Xamarin.AndroidX.Concurrent.Futures.dll => 0xd0418592 => 70
	i32 3494395880, ; 233: Xamarin.GooglePlayServices.Location.dll => 0xd0483fe8 => 124
	i32 3501239056, ; 234: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0xd0b0ab10 => 66
	i32 3509114376, ; 235: System.Xml.Linq => 0xd128d608 => 28
	i32 3536029504, ; 236: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 116
	i32 3547625832, ; 237: Xamarin.Android.Support.SlidingPaneLayout => 0xd3747968 => 54
	i32 3567349600, ; 238: System.ComponentModel.Composition.dll => 0xd4a16f60 => 136
	i32 3618140916, ; 239: Xamarin.AndroidX.Preference => 0xd7a872f4 => 98
	i32 3627220390, ; 240: Xamarin.AndroidX.Print.dll => 0xd832fda6 => 99
	i32 3632359727, ; 241: Xamarin.Forms.Platform => 0xd881692f => 117
	i32 3633644679, ; 242: Xamarin.AndroidX.Annotation.Experimental => 0xd8950487 => 61
	i32 3641597786, ; 243: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 86
	i32 3664423555, ; 244: Xamarin.Android.Support.ViewPager.dll => 0xda6aaa83 => 58
	i32 3668042751, ; 245: Microcharts.dll => 0xdaa1e3ff => 6
	i32 3672681054, ; 246: Mono.Android.dll => 0xdae8aa5e => 9
	i32 3676310014, ; 247: System.Web.Services.dll => 0xdb2009fe => 137
	i32 3681174138, ; 248: Xamarin.Android.Arch.Lifecycle.Common.dll => 0xdb6a427a => 32
	i32 3682565725, ; 249: Xamarin.AndroidX.Browser => 0xdb7f7e5d => 67
	i32 3684561358, ; 250: Xamarin.AndroidX.Concurrent.Futures => 0xdb9df1ce => 70
	i32 3689375977, ; 251: System.Drawing.Common => 0xdbe768e9 => 133
	i32 3714038699, ; 252: Xamarin.Android.Support.LocalBroadcastManager.dll => 0xdd5fbbab => 51
	i32 3718780102, ; 253: Xamarin.AndroidX.Annotation => 0xdda814c6 => 60
	i32 3724971120, ; 254: Xamarin.AndroidX.Navigation.Common.dll => 0xde068c70 => 95
	i32 3758932259, ; 255: Xamarin.AndroidX.Legacy.Support.V4 => 0xe00cc123 => 84
	i32 3776062606, ; 256: Xamarin.Android.Support.DrawerLayout.dll => 0xe112248e => 47
	i32 3786282454, ; 257: Xamarin.AndroidX.Collection => 0xe1ae15d6 => 69
	i32 3822602673, ; 258: Xamarin.AndroidX.Media => 0xe3d849b1 => 93
	i32 3829621856, ; 259: System.Numerics.dll => 0xe4436460 => 24
	i32 3832731800, ; 260: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe472d898 => 41
	i32 3862817207, ; 261: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0xe63de9b7 => 35
	i32 3874897629, ; 262: Xamarin.Android.Arch.Lifecycle.Runtime => 0xe6f63edd => 35
	i32 3885922214, ; 263: Xamarin.AndroidX.Transition.dll => 0xe79e77a6 => 105
	i32 3896760992, ; 264: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 74
	i32 3903721208, ; 265: Microcharts.Forms => 0xe8ae0ef8 => 8
	i32 3914259587, ; 266: Plugin.Connectivity => 0xe94edc83 => 13
	i32 3920810846, ; 267: System.IO.Compression.FileSystem.dll => 0xe9b2d35e => 135
	i32 3921031405, ; 268: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 108
	i32 3931092270, ; 269: Xamarin.AndroidX.Navigation.UI => 0xea4fb52e => 97
	i32 3945713374, ; 270: System.Data.DataSetExtensions.dll => 0xeb2ecede => 132
	i32 3955647286, ; 271: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 63
	i32 3967165417, ; 272: Xamarin.GooglePlayServices.Location => 0xec7623e9 => 124
	i32 3970018735, ; 273: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 127
	i32 4025670099, ; 274: Xamarin.GooglePlayServices.Places.PlaceReport => 0xeff2d9d3 => 126
	i32 4063435586, ; 275: Xamarin.Android.Support.CustomView => 0xf2331b42 => 45
	i32 4073602200, ; 276: System.Threading.dll => 0xf2ce3c98 => 139
	i32 4105002889, ; 277: Mono.Security.dll => 0xf4ad5f89 => 140
	i32 4151237749, ; 278: System.Core => 0xf76edc75 => 22
	i32 4182413190, ; 279: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0xf94a8f86 => 90
	i32 4278134329, ; 280: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 125
	i32 4292120959 ; 281: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xffd4917f => 90
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [282 x i32] [
	i32 88, i32 121, i32 11, i32 17, i32 113, i32 57, i32 102, i32 102, ; 0..7
	i32 30, i32 69, i32 40, i32 103, i32 31, i32 67, i32 114, i32 56, ; 8..15
	i32 83, i32 137, i32 72, i32 87, i32 81, i32 59, i32 115, i32 24, ; 16..23
	i32 29, i32 85, i32 42, i32 71, i32 112, i32 80, i32 10, i32 23, ; 24..31
	i32 81, i32 92, i32 118, i32 40, i32 53, i32 19, i32 131, i32 135, ; 32..39
	i32 76, i32 108, i32 64, i32 12, i32 28, i32 37, i32 118, i32 134, ; 40..47
	i32 49, i32 133, i32 99, i32 56, i32 7, i32 18, i32 53, i32 121, ; 48..55
	i32 11, i32 14, i32 52, i32 85, i32 4, i32 34, i32 29, i32 101, ; 56..63
	i32 63, i32 117, i32 89, i32 36, i32 23, i32 17, i32 106, i32 96, ; 64..71
	i32 64, i32 107, i32 16, i32 44, i32 78, i32 33, i32 128, i32 101, ; 72..79
	i32 93, i32 73, i32 3, i32 48, i32 119, i32 134, i32 62, i32 115, ; 80..87
	i32 43, i32 77, i32 8, i32 30, i32 2, i32 0, i32 91, i32 110, ; 88..95
	i32 75, i32 1, i32 26, i32 104, i32 120, i32 72, i32 21, i32 68, ; 96..103
	i32 15, i32 103, i32 22, i32 80, i32 91, i32 120, i32 97, i32 15, ; 104..111
	i32 49, i32 112, i32 119, i32 114, i32 65, i32 123, i32 36, i32 94, ; 112..119
	i32 89, i32 58, i32 50, i32 86, i32 26, i32 25, i32 82, i32 116, ; 120..127
	i32 122, i32 47, i32 43, i32 57, i32 1, i32 106, i32 92, i32 94, ; 128..135
	i32 84, i32 100, i32 60, i32 42, i32 54, i32 48, i32 98, i32 50, ; 136..143
	i32 71, i32 129, i32 5, i32 46, i32 132, i32 88, i32 107, i32 75, ; 144..151
	i32 79, i32 87, i32 0, i32 34, i32 104, i32 138, i32 3, i32 59, ; 152..159
	i32 62, i32 39, i32 113, i32 109, i32 51, i32 55, i32 20, i32 14, ; 160..167
	i32 73, i32 27, i32 122, i32 109, i32 105, i32 18, i32 55, i32 31, ; 168..175
	i32 136, i32 10, i32 20, i32 110, i32 25, i32 61, i32 45, i32 126, ; 176..183
	i32 21, i32 78, i32 125, i32 83, i32 7, i32 4, i32 38, i32 95, ; 184..191
	i32 127, i32 32, i32 138, i32 52, i32 2, i32 16, i32 130, i32 38, ; 192..199
	i32 77, i32 139, i32 123, i32 33, i32 140, i32 68, i32 66, i32 39, ; 200..207
	i32 76, i32 130, i32 46, i32 19, i32 65, i32 12, i32 96, i32 41, ; 208..215
	i32 82, i32 111, i32 44, i32 74, i32 13, i32 5, i32 100, i32 128, ; 216..223
	i32 111, i32 27, i32 129, i32 37, i32 79, i32 6, i32 9, i32 131, ; 224..231
	i32 70, i32 124, i32 66, i32 28, i32 116, i32 54, i32 136, i32 98, ; 232..239
	i32 99, i32 117, i32 61, i32 86, i32 58, i32 6, i32 9, i32 137, ; 240..247
	i32 32, i32 67, i32 70, i32 133, i32 51, i32 60, i32 95, i32 84, ; 248..255
	i32 47, i32 69, i32 93, i32 24, i32 41, i32 35, i32 35, i32 105, ; 256..263
	i32 74, i32 8, i32 13, i32 135, i32 108, i32 97, i32 132, i32 63, ; 264..271
	i32 124, i32 127, i32 126, i32 45, i32 139, i32 140, i32 22, i32 90, ; 272..279
	i32 125, i32 90 ; 280..281
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 4; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 4

; Function attributes: "frame-pointer"="all" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 4
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 4
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="all" "target-cpu"="generic" "target-features"="+armv7-a,+d32,+dsp,+fp64,+neon,+thumb-mode,+vfp2,+vfp2sp,+vfp3,+vfp3d16,+vfp3d16sp,+vfp3sp,-aes,-fp-armv8,-fp-armv8d16,-fp-armv8d16sp,-fp-armv8sp,-fp16,-fp16fml,-fullfp16,-sha2,-vfp4,-vfp4d16,-vfp4d16sp,-vfp4sp" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2}
!llvm.ident = !{!3}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"min_enum_size", i32 4}
!3 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
