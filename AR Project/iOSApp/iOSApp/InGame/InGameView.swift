//
//  MapView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

struct InGameView: View {
    @EnvironmentObject var unityManager: UnityManager
    @EnvironmentObject var soundManager: SoundManager
    
    var body: some View {
        VStack {
            HStack(spacing: 20) {
                settingButton
                
                Spacer()
                
                mapButton
                
                gameStateButton
            }
            .padding(20)
            
            Spacer()
        }
        .onChange(of: unityManager.clicker) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
        .onChange(of: unityManager.angle1) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
        .onChange(of: unityManager.angle2) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
        .onChange(of: unityManager.dodge) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
        .onChange(of: unityManager.major) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
        .onChange(of: unityManager.order) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
        .onChange(of: unityManager.rotate) { oldValue, newValue in
            if newValue == "True" {
                UINotificationFeedbackGenerator().notificationOccurred(.success)
            }
        }
    }
    
    private var settingButton: some View {
        Button {
            soundManager.playSound()
            withAnimation(.smooth) {
                unityManager.showSetting = true
            }
        } label: {
            Image(systemName: "gearshape.fill")
                .resizable()
                .scaledToFit()
                .frame(width: 26, height: 26)
                .foregroundStyle(.accent)
                .padding(12)
                .background {
                    Circle()
                        .fill(.white)
                        .shadow(color: .black.opacity(0.25), radius: 5, x: 0, y: 0)
                }
        }
    }
    
    private var gameStateButton: some View {
        Button {
            soundManager.playSound()
            withAnimation(.smooth) {
                unityManager.showGameState = true
            }
        } label: {
            Image(systemName: "pause.fill")
                .resizable()
                .scaledToFit()
                .frame(width: 26, height: 26)
                .foregroundStyle(.accent)
                .padding(12)
                .background {
                    Circle()
                        .fill(.white)
                        .shadow(color: .black.opacity(0.25), radius: 5, x: 0, y: 0)
                }
        }
    }
    
    private var mapButton: some View {
        Button {
            soundManager.playSound()
            withAnimation(.smooth) {
                unityManager.showMap = true
            }
        } label: {
            Image(systemName: "map.fill")
                .resizable()
                .scaledToFit()
                .frame(width: 26, height: 26)
                .foregroundStyle(.accent)
                .padding(12)
                .background {
                    Circle()
                        .fill(.white)
                        .shadow(color: .black.opacity(0.25), radius: 5, x: 0, y: 0)
                }
        }
    }
}

#Preview {
    InGameView()
}
