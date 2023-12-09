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
    
    @Published var startUnity: Bool = false
    @Published var showSetting: Bool = false
    @Published var showGameState: Bool = false
    
    var unityBridge: UnityBridge?
    
    func setSFXVolume(value: String) {
        unityBridge?.sendMessageToGameObject(go: "AudioManager", function: "setSfxVolume", message: value)
    }
    
    func setBGMVolume(value: String) {
        unityBridge?.sendMessageToGameObject(go: "AudioManager", function: "setBgmVolume", message: value)
    }
    
    func sendMessage(toMobileApp message: String) {
        print(message)
    }
}
