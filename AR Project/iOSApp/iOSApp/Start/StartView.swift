//
//  StartView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

struct StartView: View {
    @EnvironmentObject var unityManager: UnityManager
    @EnvironmentObject var soundManager: SoundManager
    
    @State private var unityIsLoading: Bool = false
    
    var body: some View {
        VStack(spacing: 72) {
            Spacer()
            
            character
            
            startButton
            
            Spacer()
        }
        .background(.white)
    }
    
    private var character: some View {
        HStack {
            Spacer()
            
            Image("Character")
                .resizable()
                .scaledToFit()
                .frame(height: 400)
            
            Spacer()
        }
    }
    
    private var startButton: some View {
        Button {
            soundManager.playSound()
            withAnimation(.smooth) {
                unityIsLoading = true
                unityManager.startUnity = true
            }
        } label: {
            HStack {
                Spacer()
                
                Group {
                    if unityIsLoading {
                        ProgressView()
                            .progressViewStyle(.circular)
                            .controlSize(.large)
                    } else {
                        Text("시작하기")
                    }
                }
                .foregroundStyle(Color.white)
                .font(.title2.bold())
                
                Spacer()
            }
            .padding(28)
            .background {
                RoundedRectangle(cornerRadius: 20, style: /*@START_MENU_TOKEN@*/.continuous/*@END_MENU_TOKEN@*/)
                    .shadow(color: .black.opacity(0.25), radius: 5, x: 0, y: 0)
            }
        }
        .padding(.horizontal, 36)
    }
}

#Preview {
    StartView()
}
