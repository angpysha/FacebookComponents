using Android.Content;
using Android.Runtime;
using System;
using System.Linq;

namespace Com.Facebook.Share.Model
{
	public partial class ShareContent
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareContent;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareContent;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}


			//// This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder

            static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;", "")]
			public global::Com.Facebook.Share.Model.ShareContent.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareContent$Builder;");
				global::Com.Facebook.Share.Model.ShareContent.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Facebook.Share.Model.ShareContent.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}

	public partial class ShareMedia
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareMedia;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareMedia;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}


			//// This method is explicitly implemented as a member of an instantiated Xamarin.Facebook.Share.Model.IShareModelBuilder

            static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;", "")]
			public global::Com.Facebook.Share.Model.ShareMedia.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
				global::Com.Facebook.Share.Model.ShareMedia.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Facebook.Share.Model.ShareMedia.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}

	public partial class ShareOpenGraphValueContainer
	{
		public partial class Builder
		{
			static IntPtr id_build;

            static IntPtr id_readFrom_Landroid_os_Parcel_;

		}
	}

	public partial class ShareMessengerActionButton
	{
		public partial class Builder
		{
			static IntPtr id_build;

			[Register("build", "()Lcom/facebook/share/model/ShareMessengerActionButton;", "")]
			public global::Java.Lang.Object Build()
			{
				if (id_build == IntPtr.Zero)
					id_build = JNIEnv.GetMethodID(class_ref, "build", "()Lcom/facebook/share/model/ShareMessengerActionButton;");
				return global::Java.Lang.Object.GetObject<global::Java.Lang.Object>(JNIEnv.CallObjectMethod(Handle, id_build), JniHandleOwnership.TransferLocalRef);
			}


			static IntPtr id_readFrom_Landroid_os_Parcel_;

			[Register("readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMessengerActionButton$Builder;", "")]
			public global::Com.Facebook.Share.Model.ShareMessengerActionButton.Builder ReadFrom(global::Android.OS.Parcel p0)
			{
				if (id_readFrom_Landroid_os_Parcel_ == IntPtr.Zero)
					id_readFrom_Landroid_os_Parcel_ = JNIEnv.GetMethodID(class_ref, "readFrom", "(Landroid/os/Parcel;)Lcom/facebook/share/model/ShareMedia$Builder;");
				global::Com.Facebook.Share.Model.ShareMessengerActionButton.Builder __ret = global::Java.Lang.Object.GetObject<global::Com.Facebook.Share.Model.ShareMessengerActionButton.Builder>(JNIEnv.CallObjectMethod(Handle, id_readFrom_Landroid_os_Parcel_, new JValue(p0)), JniHandleOwnership.TransferLocalRef);
				return __ret;
			}
		}
	}
}
