//
//  ContentView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI
import UnityFramework

struct RootView: View {
    @EnvironmentObject var unityManager: UnityManager
    
    var body: some View {
        if unityManager.startUnity {
            InGameView()
                .blur(radius: (unityManager.showSetting || unityManager.showGameState) ? 50 : 0)
                .overlay {
                    if unityManager.showSetting {
                        SettingView()
                    }
                    
                    if unityManager.showGameState {
                        GameStateView()
                    }
                }
        } else {
            StartView()
        }
    }
}

#Preview {
    RootView()
}
