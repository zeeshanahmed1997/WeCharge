package crc64693cf7b105c3fdd7;


public class SelectEndEditText
	extends android.widget.EditText
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFocusChanged:(ZILandroid/graphics/Rect;)V:GetOnFocusChanged_ZILandroid_graphics_Rect_Handler\n" +
			"";
		mono.android.Runtime.register ("com.refractored.monodroidtoolkit.SelectEndEditText, com.refractored.monodroidtoolkit", SelectEndEditText.class, __md_methods);
	}


	public SelectEndEditText (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SelectEndEditText.class) {
			mono.android.TypeManager.Activate ("com.refractored.monodroidtoolkit.SelectEndEditText, com.refractored.monodroidtoolkit", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public SelectEndEditText (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SelectEndEditText.class) {
			mono.android.TypeManager.Activate ("com.refractored.monodroidtoolkit.SelectEndEditText, com.refractored.monodroidtoolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public SelectEndEditText (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SelectEndEditText.class) {
			mono.android.TypeManager.Activate ("com.refractored.monodroidtoolkit.SelectEndEditText, com.refractored.monodroidtoolkit", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}


	public void onFocusChanged (boolean p0, int p1, android.graphics.Rect p2)
	{
		n_onFocusChanged (p0, p1, p2);
	}

	private native void n_onFocusChanged (boolean p0, int p1, android.graphics.Rect p2);

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
