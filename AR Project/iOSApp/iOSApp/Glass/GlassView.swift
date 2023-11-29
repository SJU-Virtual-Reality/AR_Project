//
//  GlassView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

struct TransparentBlurView: UIViewRepresentable {
    @Binding var backgroundColor: Color
    
    private var strongBlur: Bool = false
    
    init(_ strongBlur: Bool = false, backgroundColor: Binding<Color>) {
        self.strongBlur = strongBlur
        self._backgroundColor = backgroundColor
    }
    
    func makeUIView(context: Context) -> UIVisualEffectView {
        let view = UIVisualEffectView(effect: UIBlurEffect(style: strongBlur ? .systemThickMaterial : .systemUltraThinMaterial))
        
        return view
    }
    
    func updateUIView(_ uiView: UIVisualEffectView, context: Context) {
        gaussianBlurFilter(uiView)
    }
    
    func gaussianBlurFilter(_ uiView: UIVisualEffectView) {
        uiView.backgroundColor = UIColor(backgroundColor)
        
        DispatchQueue.main.async {
            if let backdropLayer = uiView.layer.sublayers?.first {
                backdropLayer.filters?.removeAll(where: { filter in
                    String(describing: filter) != "gaussianBlur"
                })
            }
        }
    }
}

enum GlassOpacity: CaseIterable {
    case ultraLight
    case extraLight
    case light
    case medium
    case heavy
    case extraHeavy
    case ultraHeavy
    
    var value: CGFloat {
        switch self {
        case .ultraLight:
            return 0.1
        case .extraLight:
            return 0.2
        case .light:
            return 0.3
        case .medium:
            return 0.4
        case .heavy:
            return 0.5
        case .extraHeavy:
            return 0.6
        case .ultraHeavy:
            return 0.7
        }
    }
}

struct GlassView: View {
    @Environment(\.colorScheme) var colorScheme
    @Environment(\.scenePhase) var scenePhase
    
    @State private var backgroundColor: Color = .clear
    
    private let opacity: GlassOpacity
    private let isStrongBlur: Bool
    private let isSemiRound: Bool
    
    init(opacity: GlassOpacity, isStrongBlur: Bool = false, isSemiRound: Bool = false) {
        self.opacity = opacity
        self.isStrongBlur = isStrongBlur
        self.isSemiRound = isSemiRound
    }
    
    var body: some View {
        ZStack {
            Color.white.opacity(opacity.value)
            
            TransparentBlurView(isStrongBlur, backgroundColor: $backgroundColor)
            
            if colorScheme == .dark {
                Color.black.opacity(opacity.value)
            } else {
                Color.white.opacity(opacity.value)
            }
        }
        .task {
            updateTransparentBlurViewTrigger()
        }
        .onChange(of: colorScheme, perform: { value in
            updateTransparentBlurViewTrigger()
        })
        .onChange(of: scenePhase, perform: { value in
            updateTransparentBlurViewTrigger()
        })
    }
    
    func updateTransparentBlurViewTrigger() {
        backgroundColor = .black
        backgroundColor = .clear
    }
}

#Preview {
    ZStack {
        Color.white
        
        ScrollView {
            VStack {
                ForEach(GlassOpacity.allCases, id: \.self) { opacity in
                    GlassView(opacity: opacity)
                        .frame(height: 100)
                    
                    GlassView(opacity: opacity, isStrongBlur: true)
                        .frame(height: 100)
                }
            }
        }
    }
}
