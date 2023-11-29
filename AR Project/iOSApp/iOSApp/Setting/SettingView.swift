//
//  SettingView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

struct SettingView: View {
    @EnvironmentObject var unityManager: UnityManager
    
    @AppStorage("FXVALUE") private var fxValue: Int = 100
    @AppStorage("BGMVALUE") private var bgmValue: Int = 100
    
    var body: some View {
        VStack(alignment: .leading) {
            HStack {
                title
                
                Spacer()
                
                closeButton
            }
            
            cell(title: "사운드")
            
            Spacer()
        }
        .padding(.horizontal, 16)
        .background {
            GlassView(opacity: .extraLight)
                .ignoresSafeArea()
        }
    }
    
    private var title: some View {
        Text("환경설정")
            .font(.largeTitle.bold())
            .foregroundStyle(.white)
    }
    
    private var closeButton: some View {
        Button {
            withAnimation(.smooth) {
                unityManager.showSetting = false
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
    
    @ViewBuilder
    private func cell(title: String) -> some View {
        VStack(alignment: .leading, spacing: 16) {
            Text(title)
                .foregroundStyle(.accent)
                .font(.headline)
            
            soundSlider(title: "효과음", value: .constant(Float(fxValue)))
            
            soundSlider(title: "배경음", value: .constant(Float(bgmValue)))
        }
        .padding(20)
        .background {
            RoundedRectangle(cornerRadius: 20, style: /*@START_MENU_TOKEN@*/.continuous/*@END_MENU_TOKEN@*/)
                .shadow(color: .black.opacity(0.25), radius: 5, x: 0, y: 0)
        }
    }
    
    @ViewBuilder
    private func soundSlider(title: String, value: Binding<Float>) -> some View {
        VStack(alignment: .leading, spacing: 0) {
            Text(title)
                .foregroundStyle(.text)
            
            Slider(value: value, in: 0...100, step: 1)
        }
    }
}

#Preview {
    SettingView()
}
