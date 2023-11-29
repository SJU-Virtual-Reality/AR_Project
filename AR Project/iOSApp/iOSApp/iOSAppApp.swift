//
//  iOSAppApp.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

@main
struct iOSAppApp: App {
    @StateObject private var unityManager = UnityManager()
    
    var body: some Scene {
        WindowGroup {
            ZStack {
                RootView()
                    .onChange(of: unityManager.startUnity) { oldValue, newValue in
                        if newValue {
                            unityManager.unityBridge = UnityBridge.getInstance()
                            unityManager.unityBridge?.show()
                            
                            if let window = unityManager.unityBridge?.view?.window {
                                // Set Unity drawing order to a lower number.
                                window.windowLevel = .normal - 10000.0
                                // Updates the background of the UIHostingView.
                                let windowUI = UIApplication.shared.windows[1]
                                if let controller = windowUI.rootViewController {
                                    controller.view.isOpaque = false
                                    controller.view.backgroundColor = UIColor(
                                        red: 0, green: 0, blue: 0, alpha: 0.0
                                    )
                                }
                            }
                        }
                    }
            }
            .environmentObject(unityManager)
        }
    }
}
