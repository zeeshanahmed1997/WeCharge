package crc64738cd6ad61f6923d;


public class CustomSearchBarRenderer
	extends crc643f46942d9dd1fff9.SearchBarRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WeCharge.Droid.Renderers.CustomSearchBarRenderer, WeCharge.Android", CustomSearchBarRenderer.class, __md_methods);
	}


	public CustomSearchBarRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == CustomSearchBarRenderer.class) {
			mono.android.TypeManager.Activate ("WeCharge.Droid.Renderers.CustomSearchBarRenderer, WeCharge.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
		}
	}


	public CustomSearchBarRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == CustomSearchBarRenderer.class) {
			mono.android.TypeManager.Activate ("WeCharge.Droid.Renderers.CustomSearchBarRenderer, WeCharge.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
		}
	}


	public CustomSearchBarRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == CustomSearchBarRenderer.class) {
			mono.android.TypeManager.Activate ("WeCharge.Droid.Renderers.CustomSearchBarRenderer, WeCharge.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
		}
	}

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
