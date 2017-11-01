using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Telephony;

namespace work2
{
    [Activity(Label = "work2", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button btnCall = FindViewById<Button>(Resource.Id.btnCall);

            btnCall.Click += delegate {
                //open dialer

                var uri1 = Android.Net.Uri.Parse("tel:6475710393");
                var intent = new Intent(Intent.ActionDial, uri1);
                StartActivity(intent);


                //dial call
                var uri2 = Android.Net.Uri.Parse("tel:6475710393");
                var callIntent = new Intent(Intent.ActionCall, uri2);
                StartActivity(callIntent);
            };

            Button btnSMS = FindViewById<Button>(Resource.Id.btnSMS);

            btnSMS.Click += delegate {

                var smsContent = FindViewById<EditText>(Resource.Id.txtSMS).Text;

                var smsUri = Android.Net.Uri.Parse("smsto:6475710393");
                var smsIntent = new Intent(Intent.ActionSendto, smsUri);
                smsIntent.PutExtra("sms_body", smsContent);
                StartActivity(smsIntent);
            };

            Button btnEmail = FindViewById<Button>(Resource.Id.btnEmail);

            btnEmail.Click += delegate {

                var email = new Intent(Android.Content.Intent.ActionSend);
                email.PutExtra(Android.Content.Intent.ExtraEmail,
                               new string[] { "harinoordeep@gmail.com", "harinoordeep@gmail.com" });

                email.PutExtra(Android.Content.Intent.ExtraCc, new string[] { "harinoordeep@gmail.com" });

                email.PutExtra(Android.Content.Intent.ExtraSubject, "Test Email");

                email.PutExtra(Android.Content.Intent.ExtraText, "This is a test email from XAMARIN Android CSD3184");

                email.SetType("message/rfc822");
                StartActivity(email);
            };
        }
    }
}