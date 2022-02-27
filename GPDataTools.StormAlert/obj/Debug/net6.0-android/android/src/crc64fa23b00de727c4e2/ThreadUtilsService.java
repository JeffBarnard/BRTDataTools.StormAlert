package crc64fa23b00de727c4e2;


public class ThreadUtilsService
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("DevExpress.Maui.Core.Android.Utils.ThreadUtilsService, DevExpress.Maui.Core", ThreadUtilsService.class, __md_methods);
	}


	public ThreadUtilsService ()
	{
		super ();
		if (getClass () == ThreadUtilsService.class)
			mono.android.TypeManager.Activate ("DevExpress.Maui.Core.Android.Utils.ThreadUtilsService, DevExpress.Maui.Core", "", this, new java.lang.Object[] {  });
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
