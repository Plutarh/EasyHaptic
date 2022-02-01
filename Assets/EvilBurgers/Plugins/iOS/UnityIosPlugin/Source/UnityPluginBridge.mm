
#import <Foundation/Foundation.h>
#include "UnityFramework/UnityFramework-Swift.h"

extern "C" {
    
#pragma mark - Functions
    

    void _StartEngine()
    {
        if (@available(iOS 13, *))
        {
            [[UnityPlugin shared] StartEngine];
        }
    }

    void _PlayTest()
    {
        if (@available(iOS 13, *))
        {
            [[UnityPlugin shared] PlayTestVib];
        }
    }

    void _PlayCustom(float intensity, float sharpness, double duration = 0)
    {
        if (@available(iOS 13, *))
        {
            [[UnityPlugin shared] PlayCustomWithIntens:(intensity) sharp:(sharpness) dur:(duration)];
        }
    }

    bool _IsHapticAvailable()
    {
        if (@available(iOS 13, *))
        {
            return  [[UnityPlugin shared] IsHapticAvailable];
        }
        else
        {
            return false;
        }
        
    }
}
