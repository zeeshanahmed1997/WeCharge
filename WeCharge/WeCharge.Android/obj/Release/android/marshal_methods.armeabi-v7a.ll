; ModuleID = 'obj/Release/android/marshal_methods.armeabi-v7a.ll'
source_filename = "obj/Release/android/marshal_methods.armeabi-v7a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [134 x i32] [
	i32 34715100, ; 0: Xamarin.Google.Guava.ListenableFuture.dll => 0x211b5dc => 61
	i32 39109920, ; 1: Newtonsoft.Json.dll => 0x254c520 => 38
	i32 39852199, ; 2: Plugin.Permissions => 0x26018a7 => 44
	i32 57263871, ; 3: Xamarin.Forms.Core.dll => 0x369c6ff => 54
	i32 182336117, ; 4: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0xade3a75 => 24
	i32 212497893, ; 5: Xamarin.Forms.Maps.Android => 0xcaa75e5 => 55
	i32 318968648, ; 6: Xamarin.AndroidX.Activity.dll => 0x13031348 => 50
	i32 319314094, ; 7: Xamarin.Forms.Maps => 0x130858ae => 56
	i32 321597661, ; 8: System.Numerics => 0x132b30dd => 7
	i32 323373387, ; 9: WeCharge.dll => 0x1346494b => 49
	i32 342366114, ; 10: Xamarin.AndroidX.Lifecycle.Common => 0x146817a2 => 19
	i32 442521989, ; 11: Xamarin.Essentials => 0x1a605985 => 53
	i32 450948140, ; 12: Xamarin.AndroidX.Fragment.dll => 0x1ae0ec2c => 17
	i32 465846621, ; 13: mscorlib => 0x1bc4415d => 4
	i32 469710990, ; 14: System.dll => 0x1bff388e => 6
	i32 501699973, ; 15: Xamarin.Forms.Skeleton => 0x1de75585 => 59
	i32 525008092, ; 16: SkiaSharp.dll => 0x1f4afcdc => 46
	i32 627609679, ; 17: Xamarin.AndroidX.CustomView => 0x2568904f => 15
	i32 663517072, ; 18: Xamarin.AndroidX.VersionedParcelable => 0x278c7790 => 25
	i32 679820142, ; 19: Plugin.Connectivity.Abstractions => 0x28853b6e => 39
	i32 690569205, ; 20: System.Xml.Linq.dll => 0x29293ff5 => 9
	i32 747088582, ; 21: Xamarin.Forms.Skeleton.dll => 0x2c87aac6 => 59
	i32 809851609, ; 22: System.Drawing.Common.dll => 0x30455ad9 => 30
	i32 886248193, ; 23: Microcharts.Droid => 0x34d31301 => 36
	i32 902159924, ; 24: Rg.Plugins.Popup => 0x35c5de34 => 45
	i32 928116545, ; 25: Xamarin.Google.Guava.ListenableFuture => 0x3751ef41 => 61
	i32 955402788, ; 26: Newtonsoft.Json => 0x38f24a24 => 38
	i32 957807352, ; 27: Plugin.CurrentActivity => 0x3916faf8 => 41
	i32 967690846, ; 28: Xamarin.AndroidX.Lifecycle.Common.dll => 0x39adca5e => 19
	i32 974778368, ; 29: FormsViewGroup.dll => 0x3a19f000 => 34
	i32 991232677, ; 30: WeCharge => 0x3b1502a5 => 49
	i32 1012816738, ; 31: Xamarin.AndroidX.SavedState.dll => 0x3c5e5b62 => 51
	i32 1035644815, ; 32: Xamarin.AndroidX.AppCompat => 0x3dbaaf8f => 11
	i32 1042160112, ; 33: Xamarin.Forms.Platform.dll => 0x3e1e19f0 => 58
	i32 1052210849, ; 34: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x3eb776a1 => 21
	i32 1098259244, ; 35: System => 0x41761b2c => 6
	i32 1137654822, ; 36: Plugin.Permissions.dll => 0x43cf3c26 => 44
	i32 1282958517, ; 37: Plugin.Geolocator => 0x4c7864b5 => 43
	i32 1293217323, ; 38: Xamarin.AndroidX.DrawerLayout.dll => 0x4d14ee2b => 16
	i32 1365406463, ; 39: System.ServiceModel.Internals.dll => 0x516272ff => 28
	i32 1376866003, ; 40: Xamarin.AndroidX.SavedState => 0x52114ed3 => 51
	i32 1406073936, ; 41: Xamarin.AndroidX.CoordinatorLayout => 0x53cefc50 => 13
	i32 1409799710, ; 42: com.refractored.monodroidtoolkit.dll => 0x5407d61e => 33
	i32 1460219004, ; 43: Xamarin.Forms.Xaml => 0x57092c7c => 60
	i32 1469204771, ; 44: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x57924923 => 10
	i32 1530663695, ; 45: Xamarin.Forms.Maps.dll => 0x5b3c130f => 56
	i32 1582526884, ; 46: Microcharts.Forms.dll => 0x5e5371a4 => 37
	i32 1592978981, ; 47: System.Runtime.Serialization.dll => 0x5ef2ee25 => 1
	i32 1599218041, ; 48: WeCharge.Android => 0x5f522179 => 32
	i32 1622152042, ; 49: Xamarin.AndroidX.Loader.dll => 0x60b0136a => 22
	i32 1639515021, ; 50: System.Net.Http.dll => 0x61b9038d => 0
	i32 1658251792, ; 51: Xamarin.Google.Android.Material.dll => 0x62d6ea10 => 27
	i32 1722051300, ; 52: SkiaSharp.Views.Forms => 0x66a46ae4 => 48
	i32 1729485958, ; 53: Xamarin.AndroidX.CardView.dll => 0x6715dc86 => 12
	i32 1732094681, ; 54: Plugin.Geofence.dll => 0x673daad9 => 42
	i32 1766324549, ; 55: Xamarin.AndroidX.SwipeRefreshLayout => 0x6947f945 => 24
	i32 1776026572, ; 56: System.Core.dll => 0x69dc03cc => 5
	i32 1788241197, ; 57: Xamarin.AndroidX.Fragment => 0x6a96652d => 17
	i32 1808609942, ; 58: Xamarin.AndroidX.Loader => 0x6bcd3296 => 22
	i32 1813201214, ; 59: Xamarin.Google.Android.Material => 0x6c13413e => 27
	i32 1861194840, ; 60: Plugin.Geofence => 0x6eef9458 => 42
	i32 1867746548, ; 61: Xamarin.Essentials.dll => 0x6f538cf4 => 53
	i32 1878053835, ; 62: Xamarin.Forms.Xaml.dll => 0x6ff0d3cb => 60
	i32 1881862856, ; 63: Xamarin.Forms.Maps.Android.dll => 0x702af2c8 => 55
	i32 1908813208, ; 64: Xamarin.GooglePlayServices.Basement => 0x71c62d98 => 63
	i32 2019465201, ; 65: Xamarin.AndroidX.Lifecycle.ViewModel => 0x785e97f1 => 21
	i32 2055257422, ; 66: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x7a80bd4e => 20
	i32 2097448633, ; 67: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x7d0486b9 => 18
	i32 2126786730, ; 68: Xamarin.Forms.Platform.Android => 0x7ec430aa => 57
	i32 2129483829, ; 69: Xamarin.GooglePlayServices.Base.dll => 0x7eed5835 => 62
	i32 2201231467, ; 70: System.Net.Http => 0x8334206b => 0
	i32 2279755925, ; 71: Xamarin.AndroidX.RecyclerView.dll => 0x87e25095 => 23
	i32 2475788418, ; 72: Java.Interop.dll => 0x93918882 => 2
	i32 2635085952, ; 73: WeCharge.Android.dll => 0x9d103880 => 32
	i32 2728372006, ; 74: com.refractored.monodroidtoolkit => 0xa29fa726 => 33
	i32 2732626843, ; 75: Xamarin.AndroidX.Activity => 0xa2e0939b => 50
	i32 2737747696, ; 76: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0xa32eb6f0 => 10
	i32 2766581644, ; 77: Xamarin.Forms.Core => 0xa4e6af8c => 54
	i32 2778768386, ; 78: Xamarin.AndroidX.ViewPager.dll => 0xa5a0a402 => 26
	i32 2795602088, ; 79: SkiaSharp.Views.Android.dll => 0xa6a180a8 => 47
	i32 2806986428, ; 80: Plugin.CurrentActivity.dll => 0xa74f36bc => 41
	i32 2810250172, ; 81: Xamarin.AndroidX.CoordinatorLayout.dll => 0xa78103bc => 13
	i32 2819470561, ; 82: System.Xml.dll => 0xa80db4e1 => 8
	i32 2847418871, ; 83: Xamarin.GooglePlayServices.Base => 0xa9b829f7 => 62
	i32 2853208004, ; 84: Xamarin.AndroidX.ViewPager => 0xaa107fc4 => 26
	i32 2861816565, ; 85: Rg.Plugins.Popup.dll => 0xaa93daf5 => 45
	i32 2905242038, ; 86: mscorlib.dll => 0xad2a79b6 => 4
	i32 2912489636, ; 87: SkiaSharp.Views.Android => 0xad9910a4 => 47
	i32 2974793899, ; 88: SkiaSharp.Views.Forms.dll => 0xb14fc0ab => 48
	i32 2978675010, ; 89: Xamarin.AndroidX.DrawerLayout => 0xb18af942 => 16
	i32 3017076677, ; 90: Xamarin.GooglePlayServices.Maps => 0xb3d4efc5 => 65
	i32 3036068679, ; 91: Microcharts.Droid.dll => 0xb4f6bb47 => 36
	i32 3044182254, ; 92: FormsViewGroup => 0xb57288ee => 34
	i32 3058099980, ; 93: Xamarin.GooglePlayServices.Tasks => 0xb646e70c => 66
	i32 3111772706, ; 94: System.Runtime.Serialization => 0xb979e222 => 1
	i32 3126016514, ; 95: Plugin.Geolocator.dll => 0xba533a02 => 43
	i32 3204380047, ; 96: System.Data.dll => 0xbefef58f => 29
	i32 3230466174, ; 97: Xamarin.GooglePlayServices.Basement.dll => 0xc08d007e => 63
	i32 3247949154, ; 98: Mono.Security => 0xc197c562 => 31
	i32 3258312781, ; 99: Xamarin.AndroidX.CardView => 0xc235e84d => 12
	i32 3317135071, ; 100: Xamarin.AndroidX.CustomView.dll => 0xc5b776df => 15
	i32 3317144872, ; 101: System.Data => 0xc5b79d28 => 29
	i32 3340387945, ; 102: SkiaSharp => 0xc71a4669 => 46
	i32 3342024700, ; 103: Plugin.Connectivity.Abstractions.dll => 0xc7333ffc => 39
	i32 3353484488, ; 104: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0xc7e21cc8 => 18
	i32 3353544232, ; 105: Xamarin.CommunityToolkit.dll => 0xc7e30628 => 52
	i32 3362522851, ; 106: Xamarin.AndroidX.Core => 0xc86c06e3 => 14
	i32 3366046733, ; 107: Plugin.Connectivity.dll => 0xc8a1cc0d => 40
	i32 3366347497, ; 108: Java.Interop => 0xc8a662e9 => 2
	i32 3374999561, ; 109: Xamarin.AndroidX.RecyclerView => 0xc92a6809 => 23
	i32 3404865022, ; 110: System.ServiceModel.Internals => 0xcaf21dfe => 28
	i32 3407215217, ; 111: Xamarin.CommunityToolkit => 0xcb15fa71 => 52
	i32 3429136800, ; 112: System.Xml => 0xcc6479a0 => 8
	i32 3455791806, ; 113: Microcharts => 0xcdfb32be => 35
	i32 3476120550, ; 114: Mono.Android => 0xcf3163e6 => 3
	i32 3494395880, ; 115: Xamarin.GooglePlayServices.Location.dll => 0xd0483fe8 => 64
	i32 3509114376, ; 116: System.Xml.Linq => 0xd128d608 => 9
	i32 3536029504, ; 117: Xamarin.Forms.Platform.Android.dll => 0xd2c38740 => 57
	i32 3632359727, ; 118: Xamarin.Forms.Platform => 0xd881692f => 58
	i32 3641597786, ; 119: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0xd90e5f5a => 20
	i32 3668042751, ; 120: Microcharts.dll => 0xdaa1e3ff => 35
	i32 3672681054, ; 121: Mono.Android.dll => 0xdae8aa5e => 3
	i32 3689375977, ; 122: System.Drawing.Common => 0xdbe768e9 => 30
	i32 3829621856, ; 123: System.Numerics.dll => 0xe4436460 => 7
	i32 3896760992, ; 124: Xamarin.AndroidX.Core.dll => 0xe843daa0 => 14
	i32 3903721208, ; 125: Microcharts.Forms => 0xe8ae0ef8 => 37
	i32 3914259587, ; 126: Plugin.Connectivity => 0xe94edc83 => 40
	i32 3921031405, ; 127: Xamarin.AndroidX.VersionedParcelable.dll => 0xe9b630ed => 25
	i32 3955647286, ; 128: Xamarin.AndroidX.AppCompat.dll => 0xebc66336 => 11
	i32 3967165417, ; 129: Xamarin.GooglePlayServices.Location => 0xec7623e9 => 64
	i32 3970018735, ; 130: Xamarin.GooglePlayServices.Tasks.dll => 0xeca1adaf => 66
	i32 4105002889, ; 131: Mono.Security.dll => 0xf4ad5f89 => 31
	i32 4151237749, ; 132: System.Core => 0xf76edc75 => 5
	i32 4278134329 ; 133: Xamarin.GooglePlayServices.Maps.dll => 0xfeff2639 => 65
], align 4
@assembly_image_cache_indices = local_unnamed_addr constant [134 x i32] [
	i32 61, i32 38, i32 44, i32 54, i32 24, i32 55, i32 50, i32 56, ; 0..7
	i32 7, i32 49, i32 19, i32 53, i32 17, i32 4, i32 6, i32 59, ; 8..15
	i32 46, i32 15, i32 25, i32 39, i32 9, i32 59, i32 30, i32 36, ; 16..23
	i32 45, i32 61, i32 38, i32 41, i32 19, i32 34, i32 49, i32 51, ; 24..31
	i32 11, i32 58, i32 21, i32 6, i32 44, i32 43, i32 16, i32 28, ; 32..39
	i32 51, i32 13, i32 33, i32 60, i32 10, i32 56, i32 37, i32 1, ; 40..47
	i32 32, i32 22, i32 0, i32 27, i32 48, i32 12, i32 42, i32 24, ; 48..55
	i32 5, i32 17, i32 22, i32 27, i32 42, i32 53, i32 60, i32 55, ; 56..63
	i32 63, i32 21, i32 20, i32 18, i32 57, i32 62, i32 0, i32 23, ; 64..71
	i32 2, i32 32, i32 33, i32 50, i32 10, i32 54, i32 26, i32 47, ; 72..79
	i32 41, i32 13, i32 8, i32 62, i32 26, i32 45, i32 4, i32 47, ; 80..87
	i32 48, i32 16, i32 65, i32 36, i32 34, i32 66, i32 1, i32 43, ; 88..95
	i32 29, i32 63, i32 31, i32 12, i32 15, i32 29, i32 46, i32 39, ; 96..103
	i32 18, i32 52, i32 14, i32 40, i32 2, i32 23, i32 28, i32 52, ; 104..111
	i32 8, i32 35, i32 3, i32 64, i32 9, i32 57, i32 58, i32 20, ; 112..119
	i32 35, i32 3, i32 30, i32 7, i32 14, i32 37, i32 40, i32 25, ; 120..127
	i32 11, i32 64, i32 66, i32 31, i32 5, i32 65 ; 128..133
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
