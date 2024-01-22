; ModuleID = 'obj/Release/android/marshal_methods.arm64-v8a.ll'
source_filename = "obj/Release/android/marshal_methods.arm64-v8a.ll"
target datalayout = "e-m:e-i8:8:32-i16:16:32-i64:64-i128:128-n32:64-S128"
target triple = "aarch64-unknown-linux-android"


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
@assembly_image_cache = local_unnamed_addr global [0 x %struct.MonoImage*] zeroinitializer, align 8
; Each entry maps hash of an assembly name to an index into the `assembly_image_cache` array
@assembly_image_cache_hashes = local_unnamed_addr constant [134 x i64] [
	i64 120698629574877762, ; 0: Mono.Android => 0x1accec39cafe242 => 3
	i64 181099460066822533, ; 1: Microcharts.Droid.dll => 0x28364ffda4c4985 => 36
	i64 232391251801502327, ; 2: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 51
	i64 263803244706540312, ; 3: Rg.Plugins.Popup.dll => 0x3a937a743542b18 => 45
	i64 435170709725415398, ; 4: Xamarin.GooglePlayServices.Location => 0x60a097471d687e6 => 64
	i64 687654259221141486, ; 5: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 62
	i64 702024105029695270, ; 6: System.Drawing.Common => 0x9be17343c0e7726 => 30
	i64 720058930071658100, ; 7: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 18
	i64 872800313462103108, ; 8: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 16
	i64 887546508555532406, ; 9: Microcharts.Forms => 0xc5132d8dc173876 => 37
	i64 996343623809489702, ; 10: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 58
	i64 1000557547492888992, ; 11: Mono.Security.dll => 0xde2b1c9cba651a0 => 31
	i64 1120440138749646132, ; 12: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 27
	i64 1400031058434376889, ; 13: Plugin.Permissions.dll => 0x136de8d4787ec4b9 => 44
	i64 1416135423712704079, ; 14: Microcharts => 0x13a71faa343e364f => 35
	i64 1425944114962822056, ; 15: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 1
	i64 1548447390495828359, ; 16: WeCharge.Android.dll => 0x157d30b297e26987 => 32
	i64 1624659445732251991, ; 17: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 10
	i64 1731380447121279447, ; 18: Newtonsoft.Json => 0x18071957e9b889d7 => 38
	i64 1795316252682057001, ; 19: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 11
	i64 1836611346387731153, ; 20: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 51
	i64 1981742497975770890, ; 21: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 21
	i64 1986553961460820075, ; 22: Xamarin.CommunityToolkit => 0x1b91a84d8004686b => 52
	i64 2133195048986300728, ; 23: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 38
	i64 2262844636196693701, ; 24: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 16
	i64 2329709569556905518, ; 25: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 20
	i64 2470498323731680442, ; 26: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 13
	i64 2547086958574651984, ; 27: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 50
	i64 2592350477072141967, ; 28: System.Xml.dll => 0x23f9e10627330e8f => 8
	i64 2624866290265602282, ; 29: mscorlib.dll => 0x246d65fbde2db8ea => 4
	i64 2801558180824670388, ; 30: Plugin.CurrentActivity.dll => 0x26e1225279a4e0b4 => 41
	i64 2960931600190307745, ; 31: Xamarin.Forms.Core => 0x2917579a49927da1 => 54
	i64 3017704767998173186, ; 32: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 27
	i64 3122911337338800527, ; 33: Microcharts.dll => 0x2b56cf50bf1e898f => 35
	i64 3289520064315143713, ; 34: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 19
	i64 3411255996856937470, ; 35: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 63
	i64 3522470458906976663, ; 36: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 24
	i64 3531994851595924923, ; 37: System.Numerics => 0x31042a9aade235bb => 7
	i64 3609787854626478660, ; 38: Plugin.CurrentActivity => 0x32188aeda587da44 => 41
	i64 3727469159507183293, ; 39: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 23
	i64 4247996603072512073, ; 40: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 66
	i64 4525561845656915374, ; 41: System.ServiceModel.Internals => 0x3ece06856b710dae => 28
	i64 4636684751163556186, ; 42: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 25
	i64 4759953996048370310, ; 43: Plugin.Geofence.dll => 0x420ec0f0a9aa0a86 => 42
	i64 4794310189461587505, ; 44: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 50
	i64 4795410492532947900, ; 45: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 24
	i64 5142919913060024034, ; 46: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 57
	i64 5203618020066742981, ; 47: Xamarin.Essentials => 0x4836f704f0e652c5 => 53
	i64 5256995213548036366, ; 48: Xamarin.Forms.Maps.Android.dll => 0x48f4994b4175a10e => 55
	i64 5507995362134886206, ; 49: System.Core.dll => 0x4c705499688c873e => 5
	i64 6085203216496545422, ; 50: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 58
	i64 6086316965293125504, ; 51: FormsViewGroup.dll => 0x5476f10882baef80 => 34
	i64 6401687960814735282, ; 52: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 20
	i64 6548213210057960872, ; 53: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 15
	i64 6659513131007730089, ; 54: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 18
	i64 6671798237668743565, ; 55: SkiaSharp => 0x5c96fd260152998d => 46
	i64 6876862101832370452, ; 56: System.Xml.Linq => 0x5f6f85a57d108914 => 9
	i64 7141281584637745974, ; 57: Xamarin.GooglePlayServices.Maps.dll => 0x631aedc3dd5f1b36 => 65
	i64 7488575175965059935, ; 58: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 9
	i64 7635363394907363464, ; 59: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 54
	i64 7637365915383206639, ; 60: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 53
	i64 7654504624184590948, ; 61: System.Net.Http => 0x6a3a4366801b8264 => 0
	i64 7820441508502274321, ; 62: System.Data => 0x6c87ca1e14ff8111 => 29
	i64 7824162571881177499, ; 63: WeCharge => 0x6c950267a9e2619b => 49
	i64 7836164640616011524, ; 64: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 10
	i64 7927939710195668715, ; 65: SkiaSharp.Views.Android.dll => 0x6e05b32992ed16eb => 47
	i64 8083354569033831015, ; 66: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 19
	i64 8167236081217502503, ; 67: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 2
	i64 8187102936927221770, ; 68: SkiaSharp.Views.Forms => 0x719e6ebe771ab80a => 48
	i64 8626175481042262068, ; 69: Java.Interop => 0x77b654e585b55834 => 2
	i64 9324707631942237306, ; 70: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 11
	i64 9439625609732276754, ; 71: Plugin.Connectivity.dll => 0x8300497a90c5c212 => 40
	i64 9662334977499516867, ; 72: System.Numerics.dll => 0x8617827802b0cfc3 => 7
	i64 9678050649315576968, ; 73: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 13
	i64 9732461928540118312, ; 74: Plugin.Connectivity.Abstractions.dll => 0x8710a68f28a59d28 => 39
	i64 9808709177481450983, ; 75: Mono.Android.dll => 0x881f890734e555e7 => 3
	i64 9875200773399460291, ; 76: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 62
	i64 9998632235833408227, ; 77: Mono.Security => 0x8ac2470b209ebae3 => 31
	i64 10038780035334861115, ; 78: System.Net.Http.dll => 0x8b50e941206af13b => 0
	i64 10229024438826829339, ; 79: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 15
	i64 10430153318873392755, ; 80: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 14
	i64 10775409704848971057, ; 81: Xamarin.Forms.Maps => 0x9589f20936d1d531 => 56
	i64 10810147764063300339, ; 82: WeCharge.dll => 0x96055c1de679eaf3 => 49
	i64 10936139690908480862, ; 83: Xamarin.Forms.Skeleton => 0x97c4f91b52a6755e => 59
	i64 11023048688141570732, ; 84: System.Core => 0x98f9bc61168392ac => 5
	i64 11037814507248023548, ; 85: System.Xml => 0x992e31d0412bf7fc => 8
	i64 11122995063473561350, ; 86: Xamarin.CommunityToolkit.dll => 0x9a5cd113fcc3df06 => 52
	i64 11162124722117608902, ; 87: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 26
	i64 11358068573944668915, ; 88: WeCharge.Android => 0x9d9ff730bc7fe2f3 => 32
	i64 11444370155346000636, ; 89: Xamarin.Forms.Maps.Android => 0x9ed292057b7afafc => 55
	i64 11529969570048099689, ; 90: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 26
	i64 11805766896659882188, ; 91: Plugin.Connectivity => 0xa3d68271607a60cc => 40
	i64 12451044538927396471, ; 92: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 17
	i64 12466513435562512481, ; 93: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 22
	i64 12501328358063843848, ; 94: Plugin.Geolocator.dll => 0xad7da3e822e9aa08 => 43
	i64 12538491095302438457, ; 95: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 12
	i64 12963446364377008305, ; 96: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 30
	i64 13370592475155966277, ; 97: System.Runtime.Serialization => 0xb98de304062ea945 => 1
	i64 13403416310143541304, ; 98: Microcharts.Droid => 0xba02801ea6c86038 => 36
	i64 13454009404024712428, ; 99: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 61
	i64 13492263892638604996, ; 100: SkiaSharp.Views.Forms.dll => 0xbb3e2686788d9ec4 => 48
	i64 13572454107664307259, ; 101: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 23
	i64 13647894001087880694, ; 102: System.Data.dll => 0xbd670f48cb071df6 => 29
	i64 13959074834287824816, ; 103: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 17
	i64 13967638549803255703, ; 104: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 57
	i64 14124974489674258913, ; 105: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 12
	i64 14633032486907445878, ; 106: Plugin.Geofence => 0xcb12f98488de8276 => 42
	i64 14678510994762383812, ; 107: Xamarin.GooglePlayServices.Location.dll => 0xcbb48bfaca7a41c4 => 64
	i64 14792063746108907174, ; 108: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 61
	i64 15370334346939861994, ; 109: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 14
	i64 15609085926864131306, ; 110: System.dll => 0xd89e9cf3334914ea => 6
	i64 15810740023422282496, ; 111: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 60
	i64 15930129725311349754, ; 112: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 66
	i64 16154507427712707110, ; 113: System => 0xe03056ea4e39aa26 => 6
	i64 16324796876805858114, ; 114: SkiaSharp.dll => 0xe28d5444586b6342 => 46
	i64 16833383113903931215, ; 115: mscorlib => 0xe99c30c1484d7f4f => 4
	i64 16895806301542741427, ; 116: Plugin.Permissions => 0xea79f6503d42f5b3 => 44
	i64 17001062948826229159, ; 117: Microcharts.Forms.dll => 0xebefe8ad2cd7a9a7 => 37
	i64 17209930810576992485, ; 118: com.refractored.monodroidtoolkit.dll => 0xeed5f4e3dd7df8e5 => 33
	i64 17238569155936077394, ; 119: Plugin.Connectivity.Abstractions => 0xef3bb3503f934652 => 39
	i64 17285063141349522879, ; 120: Rg.Plugins.Popup => 0xefe0e158cc55fdbf => 45
	i64 17353099449755952170, ; 121: com.refractored.monodroidtoolkit => 0xf0d2980246bae42a => 33
	i64 17620075112035931419, ; 122: Xamarin.Forms.Skeleton.dll => 0xf48714f5909a551b => 59
	i64 17671790519499593115, ; 123: SkiaSharp.Views.Android => 0xf53ecfd92be3959b => 47
	i64 17704177640604968747, ; 124: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 22
	i64 17710060891934109755, ; 125: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 21
	i64 17786996386789405829, ; 126: Plugin.Geolocator => 0xf6d81af967bd3485 => 43
	i64 17816041456001989629, ; 127: Xamarin.Forms.Maps.dll => 0xf73f4b4f90a1bbfd => 56
	i64 17882897186074144999, ; 128: FormsViewGroup => 0xf82cd03e3ac830e7 => 34
	i64 17892495832318972303, ; 129: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 60
	i64 17969331831154222830, ; 130: Xamarin.GooglePlayServices.Maps => 0xf95fe418471126ee => 65
	i64 17986907704309214542, ; 131: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 63
	i64 18129453464017766560, ; 132: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 28
	i64 18380184030268848184 ; 133: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 25
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [134 x i32] [
	i32 3, i32 36, i32 51, i32 45, i32 64, i32 62, i32 30, i32 18, ; 0..7
	i32 16, i32 37, i32 58, i32 31, i32 27, i32 44, i32 35, i32 1, ; 8..15
	i32 32, i32 10, i32 38, i32 11, i32 51, i32 21, i32 52, i32 38, ; 16..23
	i32 16, i32 20, i32 13, i32 50, i32 8, i32 4, i32 41, i32 54, ; 24..31
	i32 27, i32 35, i32 19, i32 63, i32 24, i32 7, i32 41, i32 23, ; 32..39
	i32 66, i32 28, i32 25, i32 42, i32 50, i32 24, i32 57, i32 53, ; 40..47
	i32 55, i32 5, i32 58, i32 34, i32 20, i32 15, i32 18, i32 46, ; 48..55
	i32 9, i32 65, i32 9, i32 54, i32 53, i32 0, i32 29, i32 49, ; 56..63
	i32 10, i32 47, i32 19, i32 2, i32 48, i32 2, i32 11, i32 40, ; 64..71
	i32 7, i32 13, i32 39, i32 3, i32 62, i32 31, i32 0, i32 15, ; 72..79
	i32 14, i32 56, i32 49, i32 59, i32 5, i32 8, i32 52, i32 26, ; 80..87
	i32 32, i32 55, i32 26, i32 40, i32 17, i32 22, i32 43, i32 12, ; 88..95
	i32 30, i32 1, i32 36, i32 61, i32 48, i32 23, i32 29, i32 17, ; 96..103
	i32 57, i32 12, i32 42, i32 64, i32 61, i32 14, i32 6, i32 60, ; 104..111
	i32 66, i32 6, i32 46, i32 4, i32 44, i32 37, i32 33, i32 39, ; 112..119
	i32 45, i32 33, i32 59, i32 47, i32 22, i32 21, i32 43, i32 56, ; 120..127
	i32 34, i32 60, i32 65, i32 63, i32 28, i32 25 ; 128..133
], align 4

@marshal_methods_number_of_classes = local_unnamed_addr constant i32 0, align 4

; marshal_methods_class_cache
@marshal_methods_class_cache = global [0 x %struct.MarshalMethodsManagedClass] [
], align 8; end of 'marshal_methods_class_cache' array


@get_function_pointer = internal unnamed_addr global void (i32, i32, i32, i8**)* null, align 8

; Function attributes: "frame-pointer"="non-leaf" "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" uwtable willreturn writeonly
define void @xamarin_app_init (void (i32, i32, i32, i8**)* %fn) local_unnamed_addr #0
{
	store void (i32, i32, i32, i8**)* %fn, void (i32, i32, i32, i8**)** @get_function_pointer, align 8
	ret void
}

; Names of classes in which marshal methods reside
@mm_class_names = local_unnamed_addr constant [0 x i8*] zeroinitializer, align 8
@__MarshalMethodName_name.0 = internal constant [1 x i8] c"\00", align 1

; mm_method_names
@mm_method_names = local_unnamed_addr constant [1 x %struct.MarshalMethodName] [
	; 0
	%struct.MarshalMethodName {
		i64 0, ; id 0x0; name: 
		i8* getelementptr inbounds ([1 x i8], [1 x i8]* @__MarshalMethodName_name.0, i32 0, i32 0); name
	}
], align 8; end of 'mm_method_names' array


attributes #0 = { "min-legal-vector-width"="0" mustprogress nofree norecurse nosync "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable willreturn writeonly "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #1 = { "min-legal-vector-width"="0" mustprogress "no-trapping-math"="true" nounwind sspstrong "stack-protector-buffer-size"="8" uwtable "frame-pointer"="non-leaf" "target-cpu"="generic" "target-features"="+neon,+outline-atomics" }
attributes #2 = { nounwind }

!llvm.module.flags = !{!0, !1, !2, !3, !4, !5}
!llvm.ident = !{!6}
!0 = !{i32 1, !"wchar_size", i32 4}
!1 = !{i32 7, !"PIC Level", i32 2}
!2 = !{i32 1, !"branch-target-enforcement", i32 0}
!3 = !{i32 1, !"sign-return-address", i32 0}
!4 = !{i32 1, !"sign-return-address-all", i32 0}
!5 = !{i32 1, !"sign-return-address-with-bkey", i32 0}
!6 = !{!"Xamarin.Android remotes/origin/d17-5 @ 45b0e144f73b2c8747d8b5ec8cbd3b55beca67f0"}
!llvm.linker.options = !{}
