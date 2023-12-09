//
//  NativeCallProxy.h
//  Unity-iPhone
//
//  Created by 김도형 on 12/6/23.
//

#ifndef NativeCallProxy_h
#define NativeCallProxy_h

#import <Foundation/Foundation.h>

@protocol NativeCallsProtocol
@required
- (void) sendMessageToMobileApp:(NSString*)message;
// other methods
@end

__attribute__ ((visibility("default")))
@interface FrameworkLibAPI : NSObject
+(void) registerAPIforNativeCalls:(id<NativeCallsProtocol>) aApi;

@end


#endif /* NativeCallProxy_h */
