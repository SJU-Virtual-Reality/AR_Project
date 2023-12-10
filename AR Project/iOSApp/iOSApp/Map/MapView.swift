//
//  MapView.swift
//  iOSApp
//
//  Created by 김도형 on 12/9/23.
//

import SwiftUI

struct MapView: View {
    enum MapPhase {
        case color
        case semiBlack
        case black
    }
    
    @EnvironmentObject var unityManager: UnityManager
    @EnvironmentObject var soundManager: SoundManager
    
    @State private var mapPhase: MapPhase = .black
    @State private var progress: Float = 0
    
    var body: some View {
        VStack(spacing: 20) {
            Spacer()
            
            switch mapPhase {
            case .color:
                 map(image: "Map")
            case .semiBlack:
                map(image: "MapSemiBlack")
            case .black:
                map(image: "MapBlack")
            }
            
            Text("현재 진척도 : \(progress)%")
                .font(.title3)
                .fontWeight(.bold)
                .foregroundStyle(.accent)
            
            Group {
                Text("진척도 : 0 ~ 50% - Black")
                
                Text("진척도 : 50 ~ 99% - SemiBlack")
                
                Text("진척도 : 100% - Color")
            }
            .font(.headline)
            
            Spacer()
        }
        .overlay(alignment: .top) {
            HStack {
                Spacer()
                
                closeButton
            }
        }
        .padding(.horizontal, 16)
        .background {
            GlassView(opacity: .extraLight)
                .ignoresSafeArea()
        }
        .onAppear() {
            progress = unityManager.calcuteProgress()
            
            switch progress {
            case 0..<50:
                mapPhase = .black
            case 50..<100:
                mapPhase = .semiBlack
            case 100:
                mapPhase = .color
            default:
                mapPhase = .black
            }
        }
    }
    
    @ViewBuilder
    private func map(image: String) -> some View {
        Image(image)
            .resizable()
            .scaledToFit()
            .frame(height: 400)
    }
    
    private var closeButton: some View {
        Button {
            soundManager.playSound()
            withAnimation(.smooth) {
                unityManager.showMap = false
            }
        } label: {
            Image(systemName: "xmark")
                .resizable()
                .scaledToFit()
                .frame(width: 20, height: 20)
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
    MapView()
}
