#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>

extern "C" {
    void _OpenURL(const char* url) {
        NSString* urlString = [NSString stringWithUTF8String:url];
        NSURL* nsUrl = [NSURL URLWithString:urlString];
        if (nsUrl == nil) return;

        if (@available(iOS 10.0, *)) {
            [[UIApplication sharedApplication] openURL:nsUrl
                                               options:@{}
                                     completionHandler:nil];
        } else {
            [[UIApplication sharedApplication] openURL:nsUrl];
        }
    }
}
