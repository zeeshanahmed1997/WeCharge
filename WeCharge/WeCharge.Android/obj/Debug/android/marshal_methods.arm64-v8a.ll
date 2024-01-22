; ModuleID = 'obj/Debug/android/marshal_methods.arm64-v8a.ll'
source_filename = "obj/Debug/android/marshal_methods.arm64-v8a.ll"
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
@assembly_image_cache_hashes = local_unnamed_addr constant [282 x i64] [
	i64 24362543149721218, ; 0: Xamarin.AndroidX.DynamicAnimation => 0x568d9a9a43a682 => 79
	i64 120698629574877762, ; 1: Mono.Android => 0x1accec39cafe242 => 9
	i64 181099460066822533, ; 2: Microcharts.Droid.dll => 0x28364ffda4c4985 => 7
	i64 210515253464952879, ; 3: Xamarin.AndroidX.Collection.dll => 0x2ebe681f694702f => 69
	i64 232391251801502327, ; 4: Xamarin.AndroidX.SavedState.dll => 0x3399e9cbc897277 => 101
	i64 263803244706540312, ; 5: Rg.Plugins.Popup.dll => 0x3a937a743542b18 => 18
	i64 295915112840604065, ; 6: Xamarin.AndroidX.SlidingPaneLayout => 0x41b4d3a3088a9a1 => 102
	i64 435170709725415398, ; 7: Xamarin.GooglePlayServices.Location => 0x60a097471d687e6 => 124
	i64 590536689428908136, ; 8: Xamarin.Android.Arch.Lifecycle.ViewModel.dll => 0x83201fd803ec868 => 36
	i64 634308326490598313, ; 9: Xamarin.AndroidX.Lifecycle.Runtime.dll => 0x8cd840fee8b6ba9 => 88
	i64 687654259221141486, ; 10: Xamarin.GooglePlayServices.Base => 0x98b09e7c92917ee => 122
	i64 702024105029695270, ; 11: System.Drawing.Common => 0x9be17343c0e7726 => 133
	i64 720058930071658100, ; 12: Xamarin.AndroidX.Legacy.Support.Core.UI => 0x9fe29c82844de74 => 82
	i64 816102801403336439, ; 13: Xamarin.Android.Support.Collections => 0xb53612c89d8d6f7 => 39
	i64 846634227898301275, ; 14: Xamarin.Android.Arch.Lifecycle.LiveData.Core => 0xbbfd9583890bb5b => 33
	i64 872800313462103108, ; 15: Xamarin.AndroidX.DrawerLayout => 0xc1ccf42c3c21c44 => 78
	i64 887546508555532406, ; 16: Microcharts.Forms => 0xc5132d8dc173876 => 8
	i64 940822596282819491, ; 17: System.Transactions => 0xd0e792aa81923a3 => 131
	i64 996343623809489702, ; 18: Xamarin.Forms.Platform => 0xdd3b93f3b63db26 => 117
	i64 1000557547492888992, ; 19: Mono.Security.dll => 0xde2b1c9cba651a0 => 140
	i64 1120440138749646132, ; 20: Xamarin.Google.Android.Material.dll => 0xf8c9a5eae431534 => 120
	i64 1315114680217950157, ; 21: Xamarin.AndroidX.Arch.Core.Common.dll => 0x124039d5794ad7cd => 64
	i64 1342439039765371018, ; 22: Xamarin.Android.Support.Fragment => 0x12a14d31b1d4d88a => 48
	i64 1400031058434376889, ; 23: Plugin.Permissions.dll => 0x136de8d4787ec4b9 => 17
	i64 1416135423712704079, ; 24: Microcharts => 0x13a71faa343e364f => 6
	i64 1425944114962822056, ; 25: System.Runtime.Serialization.dll => 0x13c9f89e19eaf3a8 => 2
	i64 1490981186906623721, ; 26: Xamarin.Android.Support.VersionedParcelable => 0x14b1077d6c5c0ee9 => 57
	i64 1548447390495828359, ; 27: WeCharge.Android.dll => 0x157d30b297e26987 => 0
	i64 1579468382457870329, ; 28: Xamarin.GooglePlayServices.Places.PlaceReport => 0x15eb66201e5cb7f9 => 126
	i64 1624659445732251991, ; 29: Xamarin.AndroidX.AppCompat.AppCompatResources.dll => 0x168bf32877da9957 => 62
	i64 1628611045998245443, ; 30: Xamarin.AndroidX.Lifecycle.ViewModelSavedState.dll => 0x1699fd1e1a00b643 => 90
	i64 1636321030536304333, ; 31: Xamarin.AndroidX.Legacy.Support.Core.Utils.dll => 0x16b5614ec39e16cd => 83
	i64 1731380447121279447, ; 32: Newtonsoft.Json => 0x18071957e9b889d7 => 11
	i64 1795316252682057001, ; 33: Xamarin.AndroidX.AppCompat.dll => 0x18ea3e9eac997529 => 63
	i64 1836611346387731153, ; 34: Xamarin.AndroidX.SavedState => 0x197cf449ebe482d1 => 101
	i64 1875917498431009007, ; 35: Xamarin.AndroidX.Annotation.dll => 0x1a08990699eb70ef => 60
	i64 1938067011858688285, ; 36: Xamarin.Android.Support.v4.dll => 0x1ae565add0bd691d => 56
	i64 1981742497975770890, ; 37: Xamarin.AndroidX.Lifecycle.ViewModel.dll => 0x1b80904d5c241f0a => 89
	i64 1986553961460820075, ; 38: Xamarin.CommunityToolkit => 0x1b91a84d8004686b => 111
	i64 2133195048986300728, ; 39: Newtonsoft.Json.dll => 0x1d9aa1984b735138 => 11
	i64 2136356949452311481, ; 40: Xamarin.AndroidX.MultiDex.dll => 0x1da5dd539d8acbb9 => 94
	i64 2165725771938924357, ; 41: Xamarin.AndroidX.Browser => 0x1e0e341d75540745 => 67
	i64 2262844636196693701, ; 42: Xamarin.AndroidX.DrawerLayout.dll => 0x1f673d352266e6c5 => 78
	i64 2284400282711631002, ; 43: System.Web.Services => 0x1fb3d1f42fd4249a => 137
	i64 2329709569556905518, ; 44: Xamarin.AndroidX.Lifecycle.LiveData.Core.dll => 0x2054ca829b447e2e => 86
	i64 2470498323731680442, ; 45: Xamarin.AndroidX.CoordinatorLayout => 0x2248f922dc398cba => 73
	i64 2479423007379663237, ; 46: Xamarin.AndroidX.VectorDrawable.Animated.dll => 0x2268ae16b2cba985 => 106
	i64 2497223385847772520, ; 47: System.Runtime => 0x22a7eb7046413568 => 26
	i64 2547086958574651984, ; 48: Xamarin.AndroidX.Activity.dll => 0x2359121801df4a50 => 59
	i64 2592350477072141967, ; 49: System.Xml.dll => 0x23f9e10627330e8f => 27
	i64 2624866290265602282, ; 50: mscorlib.dll => 0x246d65fbde2db8ea => 10
	i64 2694427813909235223, ; 51: Xamarin.AndroidX.Preference.dll => 0x256487d230fe0617 => 98
	i64 2801558180824670388, ; 52: Plugin.CurrentActivity.dll => 0x26e1225279a4e0b4 => 14
	i64 2949706848458024531, ; 53: Xamarin.Android.Support.SlidingPaneLayout => 0x28ef76c01de0a653 => 54
	i64 2960931600190307745, ; 54: Xamarin.Forms.Core => 0x2917579a49927da1 => 113
	i64 2977248461349026546, ; 55: Xamarin.Android.Support.DrawerLayout => 0x29514fb392c97af2 => 47
	i64 3017704767998173186, ; 56: Xamarin.Google.Android.Material => 0x29e10a7f7d88a002 => 120
	i64 3022227708164871115, ; 57: Xamarin.Android.Support.Media.Compat.dll => 0x29f11c168f8293cb => 52
	i64 3122911337338800527, ; 58: Microcharts.dll => 0x2b56cf50bf1e898f => 6
	i64 3289520064315143713, ; 59: Xamarin.AndroidX.Lifecycle.Common => 0x2da6b911e3063621 => 85
	i64 3303437397778967116, ; 60: Xamarin.AndroidX.Annotation.Experimental => 0x2dd82acf985b2a4c => 61
	i64 3311221304742556517, ; 61: System.Numerics.Vectors.dll => 0x2df3d23ba9e2b365 => 25
	i64 3411255996856937470, ; 62: Xamarin.GooglePlayServices.Basement => 0x2f5737416a942bfe => 123
	i64 3493805808809882663, ; 63: Xamarin.AndroidX.Tracing.Tracing.dll => 0x307c7ddf444f3427 => 104
	i64 3522470458906976663, ; 64: Xamarin.AndroidX.SwipeRefreshLayout => 0x30e2543832f52197 => 103
	i64 3531994851595924923, ; 65: System.Numerics => 0x31042a9aade235bb => 24
	i64 3571415421602489686, ; 66: System.Runtime.dll => 0x319037675df7e556 => 26
	i64 3609787854626478660, ; 67: Plugin.CurrentActivity => 0x32188aeda587da44 => 14
	i64 3716579019761409177, ; 68: netstandard.dll => 0x3393f0ed5c8c5c99 => 129
	i64 3727469159507183293, ; 69: Xamarin.AndroidX.RecyclerView => 0x33baa1739ba646bd => 100
	i64 3772598417116884899, ; 70: Xamarin.AndroidX.DynamicAnimation.dll => 0x345af645b473efa3 => 79
	i64 4247996603072512073, ; 71: Xamarin.GooglePlayServices.Tasks => 0x3af3ea6755340049 => 127
	i64 4252163538099460320, ; 72: Xamarin.Android.Support.ViewPager.dll => 0x3b02b8357f4958e0 => 58
	i64 4349341163892612332, ; 73: Xamarin.Android.Support.DocumentFile => 0x3c5bf6bea8cd9cec => 46
	i64 4416987920449902723, ; 74: Xamarin.Android.Support.AsyncLayoutInflater.dll => 0x3d4c4b1c879b9883 => 38
	i64 4525561845656915374, ; 75: System.ServiceModel.Internals => 0x3ece06856b710dae => 128
	i64 4636684751163556186, ; 76: Xamarin.AndroidX.VersionedParcelable.dll => 0x4058d0370893015a => 108
	i64 4759953996048370310, ; 77: Plugin.Geofence.dll => 0x420ec0f0a9aa0a86 => 15
	i64 4782108999019072045, ; 78: Xamarin.AndroidX.AsyncLayoutInflater.dll => 0x425d76cc43bb0a2d => 66
	i64 4794310189461587505, ; 79: Xamarin.AndroidX.Activity => 0x4288cfb749e4c631 => 59
	i64 4795410492532947900, ; 80: Xamarin.AndroidX.SwipeRefreshLayout.dll => 0x428cb86f8f9b7bbc => 103
	i64 4841234827713643511, ; 81: Xamarin.Android.Support.CoordinaterLayout => 0x432f856d041f03f7 => 41
	i64 4963205065368577818, ; 82: Xamarin.Android.Support.LocalBroadcastManager.dll => 0x44e0d8b5f4b6a71a => 51
	i64 5142919913060024034, ; 83: Xamarin.Forms.Platform.Android.dll => 0x475f52699e39bee2 => 116
	i64 5178572682164047940, ; 84: Xamarin.Android.Support.Print.dll => 0x47ddfc6acbee1044 => 53
	i64 5203618020066742981, ; 85: Xamarin.Essentials => 0x4836f704f0e652c5 => 112
	i64 5205316157927637098, ; 86: Xamarin.AndroidX.LocalBroadcastManager => 0x483cff7778e0c06a => 92
	i64 5256995213548036366, ; 87: Xamarin.Forms.Maps.Android.dll => 0x48f4994b4175a10e => 114
	i64 5288341611614403055, ; 88: Xamarin.Android.Support.Interpolator.dll => 0x4963f6ad4b3179ef => 49
	i64 5348796042099802469, ; 89: Xamarin.AndroidX.Media => 0x4a3abda9415fc165 => 93
	i64 5376510917114486089, ; 90: Xamarin.AndroidX.VectorDrawable.Animated => 0x4a9d3431719e5d49 => 106
	i64 5408338804355907810, ; 91: Xamarin.AndroidX.Transition => 0x4b0e477cea9840e2 => 105
	i64 5451019430259338467, ; 92: Xamarin.AndroidX.ConstraintLayout.dll => 0x4ba5e94a845c2ce3 => 72
	i64 5507995362134886206, ; 93: System.Core.dll => 0x4c705499688c873e => 22
	i64 5692067934154308417, ; 94: Xamarin.AndroidX.ViewPager2.dll => 0x4efe49a0d4a8bb41 => 110
	i64 5757522595884336624, ; 95: Xamarin.AndroidX.Concurrent.Futures.dll => 0x4fe6d44bd9f885f0 => 70
	i64 5767696078500135884, ; 96: Xamarin.Android.Support.Annotations.dll => 0x500af9065b6a03cc => 37
	i64 5814345312393086621, ; 97: Xamarin.AndroidX.Preference => 0x50b0b44182a5c69d => 98
	i64 5896680224035167651, ; 98: Xamarin.AndroidX.Lifecycle.LiveData.dll => 0x51d5376bfbafdda3 => 87
	i64 6044705416426755068, ; 99: Xamarin.Android.Support.SwipeRefreshLayout.dll => 0x53e31b8ccdff13fc => 55
	i64 6085203216496545422, ; 100: Xamarin.Forms.Platform.dll => 0x5472fc15a9574e8e => 117
	i64 6086316965293125504, ; 101: FormsViewGroup.dll => 0x5476f10882baef80 => 4
	i64 6311200438583329442, ; 102: Xamarin.Android.Support.LocalBroadcastManager => 0x5795e35c580c82a2 => 51
	i64 6319713645133255417, ; 103: Xamarin.AndroidX.Lifecycle.Runtime => 0x57b42213b45b52f9 => 88
	i64 6401687960814735282, ; 104: Xamarin.AndroidX.Lifecycle.LiveData.Core => 0x58d75d486341cfb2 => 86
	i64 6504860066809920875, ; 105: Xamarin.AndroidX.Browser.dll => 0x5a45e7c43bd43d6b => 67
	i64 6548213210057960872, ; 106: Xamarin.AndroidX.CustomView.dll => 0x5adfed387b066da8 => 76
	i64 6588599331800941662, ; 107: Xamarin.Android.Support.v4 => 0x5b6f682f335f045e => 56
	i64 6591024623626361694, ; 108: System.Web.Services.dll => 0x5b7805f9751a1b5e => 137
	i64 6659513131007730089, ; 109: Xamarin.AndroidX.Legacy.Support.Core.UI.dll => 0x5c6b57e8b6c3e1a9 => 82
	i64 6671798237668743565, ; 110: SkiaSharp => 0x5c96fd260152998d => 19
	i64 6876862101832370452, ; 111: System.Xml.Linq => 0x5f6f85a57d108914 => 28
	i64 6894844156784520562, ; 112: System.Numerics.Vectors => 0x5faf683aead1ad72 => 25
	i64 7036436454368433159, ; 113: Xamarin.AndroidX.Legacy.Support.V4.dll => 0x61a671acb33d5407 => 84
	i64 7103753931438454322, ; 114: Xamarin.AndroidX.Interpolator.dll => 0x62959a90372c7632 => 81
	i64 7141281584637745974, ; 115: Xamarin.GooglePlayServices.Maps.dll => 0x631aedc3dd5f1b36 => 125
	i64 7194160955514091247, ; 116: Xamarin.Android.Support.CursorAdapter.dll => 0x63d6cb45d266f6ef => 44
	i64 7345470581440696094, ; 117: Xamarin.GooglePlayServices.Places.PlaceReport.dll => 0x65f05a936adacf1e => 126
	i64 7488575175965059935, ; 118: System.Xml.Linq.dll => 0x67ecc3724534ab5f => 28
	i64 7635363394907363464, ; 119: Xamarin.Forms.Core.dll => 0x69f6428dc4795888 => 113
	i64 7637365915383206639, ; 120: Xamarin.Essentials.dll => 0x69fd5fd5e61792ef => 112
	i64 7654504624184590948, ; 121: System.Net.Http => 0x6a3a4366801b8264 => 1
	i64 7820441508502274321, ; 122: System.Data => 0x6c87ca1e14ff8111 => 130
	i64 7821246742157274664, ; 123: Xamarin.Android.Support.AsyncLayoutInflater => 0x6c8aa67926f72e28 => 38
	i64 7824162571881177499, ; 124: WeCharge => 0x6c950267a9e2619b => 29
	i64 7836164640616011524, ; 125: Xamarin.AndroidX.AppCompat.AppCompatResources => 0x6cbfa6390d64d704 => 62
	i64 7927939710195668715, ; 126: SkiaSharp.Views.Android.dll => 0x6e05b32992ed16eb => 20
	i64 8044118961405839122, ; 127: System.ComponentModel.Composition => 0x6fa2739369944712 => 136
	i64 8083354569033831015, ; 128: Xamarin.AndroidX.Lifecycle.Common.dll => 0x702dd82730cad267 => 85
	i64 8101777744205214367, ; 129: Xamarin.Android.Support.Annotations => 0x706f4beeec84729f => 37
	i64 8103644804370223335, ; 130: System.Data.DataSetExtensions.dll => 0x7075ee03be6d50e7 => 132
	i64 8167236081217502503, ; 131: Java.Interop.dll => 0x7157d9f1a9b8fd27 => 5
	i64 8187102936927221770, ; 132: SkiaSharp.Views.Forms => 0x719e6ebe771ab80a => 21
	i64 8196541262927413903, ; 133: Xamarin.Android.Support.Interpolator => 0x71bff6d9fb9ec28f => 49
	i64 8385935383968044654, ; 134: Xamarin.Android.Arch.Lifecycle.Runtime.dll => 0x7460d3cd16cb566e => 35
	i64 8398329775253868912, ; 135: Xamarin.AndroidX.ConstraintLayout.Core.dll => 0x748cdc6f3097d170 => 71
	i64 8400357532724379117, ; 136: Xamarin.AndroidX.Navigation.UI.dll => 0x749410ab44503ded => 97
	i64 8601935802264776013, ; 137: Xamarin.AndroidX.Transition.dll => 0x7760370982b4ed4d => 105
	i64 8626175481042262068, ; 138: Java.Interop => 0x77b654e585b55834 => 5
	i64 8639588376636138208, ; 139: Xamarin.AndroidX.Navigation.Runtime => 0x77e5fbdaa2fda2e0 => 96
	i64 8684531736582871431, ; 140: System.IO.Compression.FileSystem => 0x7885a79a0fa0d987 => 135
	i64 8808820144457481518, ; 141: Xamarin.Android.Support.Loader.dll => 0x7a3f374010b17d2e => 50
	i64 8917102979740339192, ; 142: Xamarin.Android.Support.DocumentFile.dll => 0x7bbfe9ea4d000bf8 => 46
	i64 9312692141327339315, ; 143: Xamarin.AndroidX.ViewPager2 => 0x813d54296a634f33 => 110
	i64 9324707631942237306, ; 144: Xamarin.AndroidX.AppCompat => 0x8168042fd44a7c7a => 63
	i64 9439625609732276754, ; 145: Plugin.Connectivity.dll => 0x8300497a90c5c212 => 13
	i64 9662334977499516867, ; 146: System.Numerics.dll => 0x8617827802b0cfc3 => 24
	i64 9678050649315576968, ; 147: Xamarin.AndroidX.CoordinatorLayout.dll => 0x864f57c9feb18c88 => 73
	i64 9711637524876806384, ; 148: Xamarin.AndroidX.Media.dll => 0x86c6aadfd9a2c8f0 => 93
	i64 9732461928540118312, ; 149: Plugin.Connectivity.Abstractions.dll => 0x8710a68f28a59d28 => 12
	i64 9808709177481450983, ; 150: Mono.Android.dll => 0x881f890734e555e7 => 9
	i64 9825649861376906464, ; 151: Xamarin.AndroidX.Concurrent.Futures => 0x885bb87d8abc94e0 => 70
	i64 9834056768316610435, ; 152: System.Transactions.dll => 0x8879968718899783 => 131
	i64 9866412715007501892, ; 153: Xamarin.Android.Arch.Lifecycle.Common.dll => 0x88ec8a16fd6b6644 => 32
	i64 9875200773399460291, ; 154: Xamarin.GooglePlayServices.Base.dll => 0x890bc2c8482339c3 => 122
	i64 9998632235833408227, ; 155: Mono.Security => 0x8ac2470b209ebae3 => 140
	i64 10038780035334861115, ; 156: System.Net.Http.dll => 0x8b50e941206af13b => 1
	i64 10229024438826829339, ; 157: Xamarin.AndroidX.CustomView => 0x8df4cb880b10061b => 76
	i64 10303855825347935641, ; 158: Xamarin.Android.Support.Loader => 0x8efea647eeb3fd99 => 50
	i64 10363495123250631811, ; 159: Xamarin.Android.Support.Collections.dll => 0x8fd287e80cd8d483 => 39
	i64 10376576884623852283, ; 160: Xamarin.AndroidX.Tracing.Tracing => 0x900101b2f888c2fb => 104
	i64 10430153318873392755, ; 161: Xamarin.AndroidX.Core => 0x90bf592ea44f6673 => 74
	i64 10635644668885628703, ; 162: Xamarin.Android.Support.DrawerLayout.dll => 0x93996679ee34771f => 47
	i64 10775409704848971057, ; 163: Xamarin.Forms.Maps => 0x9589f20936d1d531 => 115
	i64 10810147764063300339, ; 164: WeCharge.dll => 0x96055c1de679eaf3 => 29
	i64 10847732767863316357, ; 165: Xamarin.AndroidX.Arch.Core.Common => 0x968ae37a86db9f85 => 64
	i64 10850923258212604222, ; 166: Xamarin.Android.Arch.Lifecycle.Runtime => 0x9696393672c9593e => 35
	i64 10936139690908480862, ; 167: Xamarin.Forms.Skeleton => 0x97c4f91b52a6755e => 118
	i64 11023048688141570732, ; 168: System.Core => 0x98f9bc61168392ac => 22
	i64 11037814507248023548, ; 169: System.Xml => 0x992e31d0412bf7fc => 27
	i64 11122995063473561350, ; 170: Xamarin.CommunityToolkit.dll => 0x9a5cd113fcc3df06 => 111
	i64 11162124722117608902, ; 171: Xamarin.AndroidX.ViewPager => 0x9ae7d54b986d05c6 => 109
	i64 11340910727871153756, ; 172: Xamarin.AndroidX.CursorAdapter => 0x9d630238642d465c => 75
	i64 11358068573944668915, ; 173: WeCharge.Android => 0x9d9ff730bc7fe2f3 => 0
	i64 11376461258732682436, ; 174: Xamarin.Android.Support.Compat => 0x9de14f3d5fc13cc4 => 40
	i64 11392833485892708388, ; 175: Xamarin.AndroidX.Print.dll => 0x9e1b79b18fcf6824 => 99
	i64 11444370155346000636, ; 176: Xamarin.Forms.Maps.Android => 0x9ed292057b7afafc => 114
	i64 11529969570048099689, ; 177: Xamarin.AndroidX.ViewPager.dll => 0xa002ae3c4dc7c569 => 109
	i64 11578238080964724296, ; 178: Xamarin.AndroidX.Legacy.Support.V4 => 0xa0ae2a30c4cd8648 => 84
	i64 11580057168383206117, ; 179: Xamarin.AndroidX.Annotation => 0xa0b4a0a4103262e5 => 60
	i64 11597940890313164233, ; 180: netstandard => 0xa0f429ca8d1805c9 => 129
	i64 11672361001936329215, ; 181: Xamarin.AndroidX.Interpolator => 0xa1fc8e7d0a8999ff => 81
	i64 11743665907891708234, ; 182: System.Threading.Tasks => 0xa2f9e1ec30c0214a => 138
	i64 11805766896659882188, ; 183: Plugin.Connectivity => 0xa3d68271607a60cc => 13
	i64 11834399401546345650, ; 184: Xamarin.Android.Support.SlidingPaneLayout.dll => 0xa43c3b8deb43ecb2 => 54
	i64 11865714326292153359, ; 185: Xamarin.Android.Arch.Lifecycle.LiveData => 0xa4ab7c5000e8440f => 34
	i64 12137774235383566651, ; 186: Xamarin.AndroidX.VectorDrawable => 0xa872095bbfed113b => 107
	i64 12388767885335911387, ; 187: Xamarin.Android.Arch.Lifecycle.LiveData.dll => 0xabedbec0d236dbdb => 34
	i64 12414299427252656003, ; 188: Xamarin.Android.Support.Compat.dll => 0xac48738e28bad783 => 40
	i64 12451044538927396471, ; 189: Xamarin.AndroidX.Fragment.dll => 0xaccaff0a2955b677 => 80
	i64 12466513435562512481, ; 190: Xamarin.AndroidX.Loader.dll => 0xad01f3eb52569061 => 91
	i64 12487638416075308985, ; 191: Xamarin.AndroidX.DocumentFile.dll => 0xad4d00fa21b0bfb9 => 77
	i64 12501328358063843848, ; 192: Plugin.Geolocator.dll => 0xad7da3e822e9aa08 => 16
	i64 12538491095302438457, ; 193: Xamarin.AndroidX.CardView.dll => 0xae01ab382ae67e39 => 68
	i64 12550732019250633519, ; 194: System.IO.Compression => 0xae2d28465e8e1b2f => 134
	i64 12700543734426720211, ; 195: Xamarin.AndroidX.Collection => 0xb041653c70d157d3 => 69
	i64 12952608645614506925, ; 196: Xamarin.Android.Support.Core.Utils => 0xb3c0e8eff48193ad => 43
	i64 12963446364377008305, ; 197: System.Drawing.Common.dll => 0xb3e769c8fd8548b1 => 133
	i64 13358059602087096138, ; 198: Xamarin.Android.Support.Fragment.dll => 0xb9615c6f1ee5af4a => 48
	i64 13370592475155966277, ; 199: System.Runtime.Serialization => 0xb98de304062ea945 => 2
	i64 13401370062847626945, ; 200: Xamarin.AndroidX.VectorDrawable.dll => 0xb9fb3b1193964ec1 => 107
	i64 13403416310143541304, ; 201: Microcharts.Droid => 0xba02801ea6c86038 => 7
	i64 13404347523447273790, ; 202: Xamarin.AndroidX.ConstraintLayout.Core => 0xba05cf0da4f6393e => 71
	i64 13454009404024712428, ; 203: Xamarin.Google.Guava.ListenableFuture => 0xbab63e4543a86cec => 121
	i64 13491513212026656886, ; 204: Xamarin.AndroidX.Arch.Core.Runtime.dll => 0xbb3b7bc905569876 => 65
	i64 13492263892638604996, ; 205: SkiaSharp.Views.Forms.dll => 0xbb3e2686788d9ec4 => 21
	i64 13572454107664307259, ; 206: Xamarin.AndroidX.RecyclerView.dll => 0xbc5b0b19d99f543b => 100
	i64 13647894001087880694, ; 207: System.Data.dll => 0xbd670f48cb071df6 => 130
	i64 13959074834287824816, ; 208: Xamarin.AndroidX.Fragment => 0xc1b8989a7ad20fb0 => 80
	i64 13967638549803255703, ; 209: Xamarin.Forms.Platform.Android => 0xc1d70541e0134797 => 116
	i64 14124974489674258913, ; 210: Xamarin.AndroidX.CardView => 0xc405fd76067d19e1 => 68
	i64 14125464355221830302, ; 211: System.Threading.dll => 0xc407bafdbc707a9e => 139
	i64 14172845254133543601, ; 212: Xamarin.AndroidX.MultiDex => 0xc4b00faaed35f2b1 => 94
	i64 14261073672896646636, ; 213: Xamarin.AndroidX.Print => 0xc5e982f274ae0dec => 99
	i64 14400856865250966808, ; 214: Xamarin.Android.Support.Core.UI => 0xc7da1f051a877d18 => 42
	i64 14486659737292545672, ; 215: Xamarin.AndroidX.Lifecycle.LiveData => 0xc90af44707469e88 => 87
	i64 14633032486907445878, ; 216: Plugin.Geofence => 0xcb12f98488de8276 => 15
	i64 14644440854989303794, ; 217: Xamarin.AndroidX.LocalBroadcastManager.dll => 0xcb3b815e37daeff2 => 92
	i64 14661790646341542033, ; 218: Xamarin.Android.Support.SwipeRefreshLayout => 0xcb7924e94e552091 => 55
	i64 14678510994762383812, ; 219: Xamarin.GooglePlayServices.Location.dll => 0xcbb48bfaca7a41c4 => 124
	i64 14792063746108907174, ; 220: Xamarin.Google.Guava.ListenableFuture.dll => 0xcd47f79af9c15ea6 => 121
	i64 14852515768018889994, ; 221: Xamarin.AndroidX.CursorAdapter.dll => 0xce1ebc6625a76d0a => 75
	i64 14987728460634540364, ; 222: System.IO.Compression.dll => 0xcfff1ba06622494c => 134
	i64 14988210264188246988, ; 223: Xamarin.AndroidX.DocumentFile => 0xd000d1d307cddbcc => 77
	i64 15188640517174936311, ; 224: Xamarin.Android.Arch.Core.Common => 0xd2c8e413d75142f7 => 30
	i64 15246441518555807158, ; 225: Xamarin.Android.Arch.Core.Common.dll => 0xd3963dc832493db6 => 30
	i64 15326820765897713587, ; 226: Xamarin.Android.Arch.Core.Runtime.dll => 0xd4b3ce481769e7b3 => 31
	i64 15370334346939861994, ; 227: Xamarin.AndroidX.Core.dll => 0xd54e65a72c560bea => 74
	i64 15457813392950723921, ; 228: Xamarin.Android.Support.Media.Compat => 0xd6852f61c31a8551 => 52
	i64 15568534730848034786, ; 229: Xamarin.Android.Support.VersionedParcelable.dll => 0xd80e8bda21875fe2 => 57
	i64 15582737692548360875, ; 230: Xamarin.AndroidX.Lifecycle.ViewModelSavedState => 0xd841015ed86f6aab => 90
	i64 15609085926864131306, ; 231: System.dll => 0xd89e9cf3334914ea => 23
	i64 15777549416145007739, ; 232: Xamarin.AndroidX.SlidingPaneLayout.dll => 0xdaf51d99d77eb47b => 102
	i64 15810740023422282496, ; 233: Xamarin.Forms.Xaml => 0xdb6b08484c22eb00 => 119
	i64 15817206913877585035, ; 234: System.Threading.Tasks.dll => 0xdb8201e29086ac8b => 138
	i64 15930129725311349754, ; 235: Xamarin.GooglePlayServices.Tasks.dll => 0xdd1330956f12f3fa => 127
	i64 16154507427712707110, ; 236: System => 0xe03056ea4e39aa26 => 23
	i64 16242842420508142678, ; 237: Xamarin.Android.Support.CoordinaterLayout.dll => 0xe16a2b1f8908ac56 => 41
	i64 16324796876805858114, ; 238: SkiaSharp.dll => 0xe28d5444586b6342 => 19
	i64 16565028646146589191, ; 239: System.ComponentModel.Composition.dll => 0xe5e2cdc9d3bcc207 => 136
	i64 16621146507174665210, ; 240: Xamarin.AndroidX.ConstraintLayout => 0xe6aa2caf87dedbfa => 72
	i64 16677317093839702854, ; 241: Xamarin.AndroidX.Navigation.UI => 0xe771bb8960dd8b46 => 97
	i64 16767985610513713374, ; 242: Xamarin.Android.Arch.Core.Runtime => 0xe8b3da12798808de => 31
	i64 16822611501064131242, ; 243: System.Data.DataSetExtensions => 0xe975ec07bb5412aa => 132
	i64 16833383113903931215, ; 244: mscorlib => 0xe99c30c1484d7f4f => 10
	i64 16895806301542741427, ; 245: Plugin.Permissions => 0xea79f6503d42f5b3 => 17
	i64 16932527889823454152, ; 246: Xamarin.Android.Support.Core.Utils.dll => 0xeafc6c67465253c8 => 43
	i64 17001062948826229159, ; 247: Microcharts.Forms.dll => 0xebefe8ad2cd7a9a7 => 8
	i64 17024911836938395553, ; 248: Xamarin.AndroidX.Annotation.Experimental.dll => 0xec44a31d250e5fa1 => 61
	i64 17031351772568316411, ; 249: Xamarin.AndroidX.Navigation.Common.dll => 0xec5b843380a769fb => 95
	i64 17037200463775726619, ; 250: Xamarin.AndroidX.Legacy.Support.Core.Utils => 0xec704b8e0a78fc1b => 83
	i64 17209930810576992485, ; 251: com.refractored.monodroidtoolkit.dll => 0xeed5f4e3dd7df8e5 => 3
	i64 17238569155936077394, ; 252: Plugin.Connectivity.Abstractions => 0xef3bb3503f934652 => 12
	i64 17285063141349522879, ; 253: Rg.Plugins.Popup => 0xefe0e158cc55fdbf => 18
	i64 17353099449755952170, ; 254: com.refractored.monodroidtoolkit => 0xf0d2980246bae42a => 3
	i64 17383232329670771222, ; 255: Xamarin.Android.Support.CustomView.dll => 0xf13da5b41a1cc216 => 45
	i64 17428701562824544279, ; 256: Xamarin.Android.Support.Core.UI.dll => 0xf1df2fbaec73d017 => 42
	i64 17483646997724851973, ; 257: Xamarin.Android.Support.ViewPager => 0xf2a2644fe5b6ef05 => 58
	i64 17524135665394030571, ; 258: Xamarin.Android.Support.Print => 0xf3323c8a739097eb => 53
	i64 17544493274320527064, ; 259: Xamarin.AndroidX.AsyncLayoutInflater => 0xf37a8fada41aded8 => 66
	i64 17620075112035931419, ; 260: Xamarin.Forms.Skeleton.dll => 0xf48714f5909a551b => 118
	i64 17666959971718154066, ; 261: Xamarin.Android.Support.CustomView => 0xf52da67d9f4e4752 => 45
	i64 17671790519499593115, ; 262: SkiaSharp.Views.Android => 0xf53ecfd92be3959b => 20
	i64 17704177640604968747, ; 263: Xamarin.AndroidX.Loader => 0xf5b1dfc36cac272b => 91
	i64 17710060891934109755, ; 264: Xamarin.AndroidX.Lifecycle.ViewModel => 0xf5c6c68c9e45303b => 89
	i64 17760961058993581169, ; 265: Xamarin.Android.Arch.Lifecycle.Common => 0xf67b9bfb46dbac71 => 32
	i64 17786996386789405829, ; 266: Plugin.Geolocator => 0xf6d81af967bd3485 => 16
	i64 17816041456001989629, ; 267: Xamarin.Forms.Maps.dll => 0xf73f4b4f90a1bbfd => 115
	i64 17841643939744178149, ; 268: Xamarin.Android.Arch.Lifecycle.ViewModel => 0xf79a40a25573dfe5 => 36
	i64 17882897186074144999, ; 269: FormsViewGroup => 0xf82cd03e3ac830e7 => 4
	i64 17892495832318972303, ; 270: Xamarin.Forms.Xaml.dll => 0xf84eea293687918f => 119
	i64 17928294245072900555, ; 271: System.IO.Compression.FileSystem.dll => 0xf8ce18a0b24011cb => 135
	i64 17958105683855786126, ; 272: Xamarin.Android.Arch.Lifecycle.LiveData.Core.dll => 0xf93801f92d25c08e => 33
	i64 17969331831154222830, ; 273: Xamarin.GooglePlayServices.Maps => 0xf95fe418471126ee => 125
	i64 17986907704309214542, ; 274: Xamarin.GooglePlayServices.Basement.dll => 0xf99e554223166d4e => 123
	i64 18025913125965088385, ; 275: System.Threading => 0xfa28e87b91334681 => 139
	i64 18116111925905154859, ; 276: Xamarin.AndroidX.Arch.Core.Runtime => 0xfb695bd036cb632b => 65
	i64 18121036031235206392, ; 277: Xamarin.AndroidX.Navigation.Common => 0xfb7ada42d3d42cf8 => 95
	i64 18129453464017766560, ; 278: System.ServiceModel.Internals.dll => 0xfb98c1df1ec108a0 => 128
	i64 18301997741680159453, ; 279: Xamarin.Android.Support.CursorAdapter => 0xfdfdc1fa58d8eadd => 44
	i64 18305135509493619199, ; 280: Xamarin.AndroidX.Navigation.Runtime.dll => 0xfe08e7c2d8c199ff => 96
	i64 18380184030268848184 ; 281: Xamarin.AndroidX.VersionedParcelable => 0xff1387fe3e7b7838 => 108
], align 8
@assembly_image_cache_indices = local_unnamed_addr constant [282 x i32] [
	i32 79, i32 9, i32 7, i32 69, i32 101, i32 18, i32 102, i32 124, ; 0..7
	i32 36, i32 88, i32 122, i32 133, i32 82, i32 39, i32 33, i32 78, ; 8..15
	i32 8, i32 131, i32 117, i32 140, i32 120, i32 64, i32 48, i32 17, ; 16..23
	i32 6, i32 2, i32 57, i32 0, i32 126, i32 62, i32 90, i32 83, ; 24..31
	i32 11, i32 63, i32 101, i32 60, i32 56, i32 89, i32 111, i32 11, ; 32..39
	i32 94, i32 67, i32 78, i32 137, i32 86, i32 73, i32 106, i32 26, ; 40..47
	i32 59, i32 27, i32 10, i32 98, i32 14, i32 54, i32 113, i32 47, ; 48..55
	i32 120, i32 52, i32 6, i32 85, i32 61, i32 25, i32 123, i32 104, ; 56..63
	i32 103, i32 24, i32 26, i32 14, i32 129, i32 100, i32 79, i32 127, ; 64..71
	i32 58, i32 46, i32 38, i32 128, i32 108, i32 15, i32 66, i32 59, ; 72..79
	i32 103, i32 41, i32 51, i32 116, i32 53, i32 112, i32 92, i32 114, ; 80..87
	i32 49, i32 93, i32 106, i32 105, i32 72, i32 22, i32 110, i32 70, ; 88..95
	i32 37, i32 98, i32 87, i32 55, i32 117, i32 4, i32 51, i32 88, ; 96..103
	i32 86, i32 67, i32 76, i32 56, i32 137, i32 82, i32 19, i32 28, ; 104..111
	i32 25, i32 84, i32 81, i32 125, i32 44, i32 126, i32 28, i32 113, ; 112..119
	i32 112, i32 1, i32 130, i32 38, i32 29, i32 62, i32 20, i32 136, ; 120..127
	i32 85, i32 37, i32 132, i32 5, i32 21, i32 49, i32 35, i32 71, ; 128..135
	i32 97, i32 105, i32 5, i32 96, i32 135, i32 50, i32 46, i32 110, ; 136..143
	i32 63, i32 13, i32 24, i32 73, i32 93, i32 12, i32 9, i32 70, ; 144..151
	i32 131, i32 32, i32 122, i32 140, i32 1, i32 76, i32 50, i32 39, ; 152..159
	i32 104, i32 74, i32 47, i32 115, i32 29, i32 64, i32 35, i32 118, ; 160..167
	i32 22, i32 27, i32 111, i32 109, i32 75, i32 0, i32 40, i32 99, ; 168..175
	i32 114, i32 109, i32 84, i32 60, i32 129, i32 81, i32 138, i32 13, ; 176..183
	i32 54, i32 34, i32 107, i32 34, i32 40, i32 80, i32 91, i32 77, ; 184..191
	i32 16, i32 68, i32 134, i32 69, i32 43, i32 133, i32 48, i32 2, ; 192..199
	i32 107, i32 7, i32 71, i32 121, i32 65, i32 21, i32 100, i32 130, ; 200..207
	i32 80, i32 116, i32 68, i32 139, i32 94, i32 99, i32 42, i32 87, ; 208..215
	i32 15, i32 92, i32 55, i32 124, i32 121, i32 75, i32 134, i32 77, ; 216..223
	i32 30, i32 30, i32 31, i32 74, i32 52, i32 57, i32 90, i32 23, ; 224..231
	i32 102, i32 119, i32 138, i32 127, i32 23, i32 41, i32 19, i32 136, ; 232..239
	i32 72, i32 97, i32 31, i32 132, i32 10, i32 17, i32 43, i32 8, ; 240..247
	i32 61, i32 95, i32 83, i32 3, i32 12, i32 18, i32 3, i32 45, ; 248..255
	i32 42, i32 58, i32 53, i32 66, i32 118, i32 45, i32 20, i32 91, ; 256..263
	i32 89, i32 32, i32 16, i32 115, i32 36, i32 4, i32 119, i32 135, ; 264..271
	i32 33, i32 125, i32 123, i32 139, i32 65, i32 95, i32 128, i32 44, ; 272..279
	i32 96, i32 108 ; 280..281
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
