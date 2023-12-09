//
//  GameState.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

struct GameStateView: View {
    @EnvironmentObject var unityManager: UnityManager
    @EnvironmentObject var soundManager: SoundManager
    
    var body: some View {
        VStack(spacing: 20) {
            Spacer()
            
            gameStateButton(title: "다시하기") {
                soundManager.playSound()
                
            }
            
            gameStateButton(title: "계속하기") {
                soundManager.playSound()
                withAnimation(.smooth) {
                    unityManager.showGameState = false
                }
            }
            
            gameStateButton(title: "게임 끝내기") {
                soundManager.playSound()
                withAnimation(.smooth) {
                    unityManager.startUnity = false
                    unityManager.unityBridge?.unload()
                    unityManager.showGameState = false
                }
            }
            
            Spacer()
        }
        .padding(.horizontal, 36)
        .background {
            GlassView(opacity: .extraLight)
                .ignoresSafeArea()
        }
    }
    
    @ViewBuilder
    private func gameStateButton(title: String, action: @escaping () -> Void) -> some View {
        Button(action: action) {
            HStack {
                Spacer()
                
                Text(title)
                    .font(.title2.bold())
                    .foregroundStyle(.accent)
                
                Spacer()
            }
            .padding(20)
            .background {
                RoundedRectangle(cornerRadius: 20, style: /*@START_MENU_TOKEN@*/.continuous/*@END_MENU_TOKEN@*/)
                    .fill(.white)
                    .shadow(color: .black.opacity(0.25), radius: 5, x: 0, y: 0)
            }
        }
    }
}

#Preview {
    GameStateView()
}
