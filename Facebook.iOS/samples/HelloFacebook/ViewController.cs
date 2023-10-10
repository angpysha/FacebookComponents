using System;

using UIKit;
using System.Collections.Generic;

using Facebook.LoginKit;
using Facebook.CoreKit;
using CoreGraphics;
using Foundation;
using static CoreFoundation.DispatchSource;

namespace HelloFacebook
{
	public partial class ViewController : UIViewController, IFBSDKLoginButtonDelegate
	{
		// To see the full list of permissions, visit the following link:
		// https://developers.facebook.com/docs/facebook-login/permissions/v2.3

		// This permission is set by default, even if you don't add it, but FB recommends to add it anyway
		List<string> readPermissions = new List<string> { "public_profile" };
		FBSDKProfile profile;
		FBSDKLoginButton loginButton;
		FBSDKProfilePictureView pictureView;
		UILabel nameLabel;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

			// If was send true to Profile.EnableUpdatesOnAccessTokenChange method
			// this notification will be called after the user is logged in and
			// after the AccessToken is gotten
			// FBSDKProfile.Notifications.ObserveDidChange ((sender, e) => {
			//
			// 	if (e.NewProfile == null)
			// 		return;
			//
			// 	nameLabel.Text = e.NewProfile.Name;
			// });
			var proo = FBSDKAuthenticationStatusUtility.ProfileSetter;
			var iii = 0;
			// Set the Read and Publish permissions you want to get
			loginButton = new FBSDKLoginButton (new CGRect (80, 20, 220, 46)) {
				Permissions = readPermissions.ToArray (),
				Delegate = this
			};

			// The user image profile is set automatically once is logged in
			pictureView = new FBSDKProfilePictureView (new CGRect (80, 100, 220, 220), profile);

			// Create the label that will hold user's facebook name
			nameLabel = new UILabel (new CGRect (80, 340, 220, 21)) {
				TextAlignment = UITextAlignment.Center,
				BackgroundColor = UIColor.Clear
			};

			// If you have been logged into the app before, ask for the your profile name
			if (FBSDKAccessToken.CurrentAccessToken != null) {

				BSDKProfile_FBSDKCoreKit_Swift_883.LoadCurrentProfileWithCompletion ((profile, error) => {
					int iiei = 0;
				});

				var request = new FBSDKGraphRequest ("/me", new NSDictionary<NSString, NSObject>(), FBSDKAccessToken.CurrentAccessToken.TokenString, null, "GET");
				request.StartWithCompletion ((connection, result, error) => {
					// Handle if something went wrong with the request
					if (error != null) {
						new UIAlertView ("Error...", error.Description, null, "Ok", null).Show ();
						return;
					}

					// Get your profile name
					var userInfo = result as NSDictionary;
					nameLabel.Text = userInfo ["name"].ToString ();
				});

				//		var facebookProfileUrl = NSURL (string: "http://graph.facebook.com/\(userID)/picture?type=large")

				//      if let data = NSData (contentsOfURL: facebookProfileUrl!) {
				//			imageProfile.image = UIImage (data: data)

				//}

				//var facebookProfileUrl = new NSUrl ($@"http://graph.facebook.com/{FBSDKAccessToken.CurrentAccessToken}/picture?type=large");
				//var data = NSData.FromUrl (facebookProfileUrl);

				//if (data is not null) {
				//	//pictureView.Image = new UIImage (data);
				//}
			}

			// Add views to main view
			View.AddSubview (loginButton);
			View.AddSubview (pictureView);
			View.AddSubview (nameLabel);
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		// Handle actions once the user is logged in
		public void LoginButton (FBSDKLoginButton loginButton, FBSDKLoginManagerLoginResult result, NSError error)
        {
				if (error != null)
				{
					// Handle if there was an error
					new UIAlertView("Login", error.Description, null, "Ok", null).Show();
					return;
				}

				if (result.IsCancelled)
				{
					// Handle if the user cancelled the login request
					new UIAlertView("Login", "The user cancelled the login", null, "Ok", null).Show();
					return;
				}

				// Handle your successful login
				new UIAlertView("Login", "Success!!", null, "Ok", null).Show();
        }

        // Handle actions once the user is logged out
        public void LoginButtonDidLogOut (FBSDKLoginButton loginButton)
        {
            // Handle your logout
            nameLabel.Text = "";
        }
	}
}

