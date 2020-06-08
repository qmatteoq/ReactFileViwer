#pragma once

#include "winrt/Microsoft.ReactNative.h"



using namespace winrt::Microsoft::ReactNative;

namespace winrt::ReactFileViewer::implementation
{

    struct ReactPackageProvider : winrt::implements<ReactPackageProvider, IReactPackageProvider>
    {
    public: // IReactPackageProvider
        void CreatePackage(IReactPackageBuilder const &packageBuilder) noexcept;
    };

} // namespace winrt::ReactFileViewer::implementation


