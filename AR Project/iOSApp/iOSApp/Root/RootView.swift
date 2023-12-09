//
//  ContentView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI
import UnityFramework

struct RootView: View {
    @StateObject var unityManager: UnityManager = .init()
    
    var body: some View {
        if unityManager.startUnity {
            ZStack {
                InGameView()
                    .onAppear() {
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
                    .blur(radius: (unityManager.showSetting || unityManager.showGameState) ? 50 : 0)
                    .overlay {
                        if unityManager.showSetting {
                            SettingView()
                        }
                        
                        if unityManager.showGameState {
                            GameStateView()
                        }
                    }
                    .environmentObject(unityManager)
            }
        } else {
            StartView()
                .environmentObject(unityManager)
        }
    }
}

#Preview {
    RootView()
}
