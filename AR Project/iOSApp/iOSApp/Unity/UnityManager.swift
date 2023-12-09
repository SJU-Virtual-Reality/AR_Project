//
//  UnityManager.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI
import UnityFramework

class UnityManager: NSObject, ObservableObject, NativeCallsProtocol {
    override init() {
        super.init()
        
        NSClassFromString("FrameworkLibAPI")?.registerAPIforNativeCalls(self)
    }
    
    func sendMessage(toMobileApp message: String) {
        print(message)
    }
    
    @Published var startUnity: Bool = false
    @Published var showSetting: Bool = false
    @Published var showGameState: Bool = false
    
    var unityBridge: UnityBridge?
}
