 # PhotoEditorService

## Summary

The `PhotoEditorService` allows the edition of a Picture using the PhotoEditorSDK bindings

## Platform support

| Feature                              | UWA | Android | iOS |
| ------------------------------------ |:---:|:-------:|:---:|
| Determine if a permission is granted |  -  |    X    |  X  |
| Request a permission                 |  -  |    X    |  X  |

## Usage

- For **Android**,
    1. Override `OnActivityResult` in your main Android activity in order to send the back the edited
    to the PhotoEditorService.
        For example,
    ```csharp
    public MainActivity : FragmentActivity
    {
        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (requestCode == EDITOR_ACTIVITY_REQUEST)
            {
                //Delete the SourceImage if needed
                var sourceImage = data?.GetParcelableExtra(ImgLyIntent.SourceImageUri) as Android.Net.Uri;
                if (sourceImage != null)
                {
                    File.Delete(sourceImage.Path);
                }

                var resultUri = resultCode == Result.Ok
                    ? data.GetParcelableExtra(ImgLyIntent.ResultImageUri) as Android.Net.Uri
                    : null;

                ServiceLocator.Current
                    .GetInstance<IPhotoEditorService>()
                    .OnPhotoEditingEnded(resultUri);
            }
        }
    }
    ```

    2. Register the service.
    ```csharp
    container.Register<IPhotoEditorService>(c => new PhotoEditorService(
        () => (Activity)Uno.UI.ContextHelper.Current, 
        () => c.Resolve<IPermissionsService>()
    ));
    ```
- For **iOS**,

    1. Register the service.
    ```csharp
    container.Register<IPhotoEditorService>(c => new PhotoEditorService());

- **Use the service**,
    
    ```csharp
    //This method takes a StreamProvider as parameter
    var editedMedia = container.Resolve<IPhotoEditorService>().EditPhoto(ct, media);

    // Use the extension methods in PermissionsServiceExtensions to get predefined permissions.
    var hasCameraPermission = permissionsService.TryGetCameraPermission(ct);

    // Use the service directly if the required permission is not in the list of extensions.
    var hasOtherPermission = permissionsService.TryGetPermission(ct, Manifest.Permission.OtherPermission);
    ```

### Remarks
Applications using **Uno.UI** can use the extension method `BaseActivity.ObserveRequestPermissionsResultWithResults` without having to create the Observable sequence. This is because all **Uno.UI** applications inherit from `BaseActivity` and this is provided by default. Simply provide that observable when creating the service.

## Known issues

None.