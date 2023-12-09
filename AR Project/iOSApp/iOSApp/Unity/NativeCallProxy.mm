//
//  NativeCallProxy.m
//  Unity-iPhone
//
//  Created by 김도형 on 12/6/23.
//

#import <Foundation/Foundation.h>
#import "NativeCallProxy.h"

@implementation FrameworkLibAPI

id<NativeCallsProtocol> api = NULL;
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi
{
    api = aApi;
}

@end

extern "C"
{
    void sendMessageToMobileApp(const char* message)
    {
        return [api sendMessageToMobileApp:[NSString stringWithUTF8String:message]];
    }
}
