//
//  UnityView.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI
import UnityFramework

struct UnityView: UIViewControllerRepresentable {
    func makeUIViewController(context: Context) -> UIViewController {
        let vc = UIViewController()
        let unityBridge = UnityBridge()
        
        unityBridge.show(controller: vc)
        return vc
      }

      func updateUIViewController(_ viewController: UIViewController, context: Context) {}
}
