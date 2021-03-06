﻿using Windows.Storage;
using Windows.System;
using System;
using Microsoft.ReactNative.Managed;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.ApplicationModel.Core;

namespace RNFileViewer
{
    /// <summary>
    /// A module that allows JS to share data.
    /// </summary>
    [ReactModule("RNFileViewer")]
    class RNFileViewerModule
    {

        [ReactMethod("open")]
        public async void Open(string filepath, IReactPromise<bool> promise)
        {
            try
            {
                var file = await StorageFile.GetFileFromPathAsync(filepath);

                if (file != null)
                {
                    await CoreApplication.MainView.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, async () =>
                     {
                         var success = await Launcher.LaunchFileAsync(file);

                         if (success)
                         {
                             promise.Resolve(true);
                         }
                         else
                         {
                             promise.Reject(new ReactError { Message = $"Error opening the file {filepath}" });
                         }
                     });
                }
                else
                {
                    promise.Reject(new ReactError { Message = $"Error loading the file {filepath}" });
                }
            }
            catch (Exception e)
            {
                promise.Reject(new ReactError { Exception = e });
            }
        }
    }
}
