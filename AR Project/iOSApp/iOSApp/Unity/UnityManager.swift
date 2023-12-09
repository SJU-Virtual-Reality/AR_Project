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
    
    @AppStorage("GameClearData_Clicker") private var clicker: Bool = false
    @AppStorage("GameClearData_Angle1") private var angle1: Bool = false
    @AppStorage("GameClearData_Order") private var order: Bool = false
    @AppStorage("GameClearData_Dodge") private var dodge: Bool = false
    @AppStorage("GameClearData_Major") private var major: Bool = false
    @AppStorage("GameClearData_Rotate") private var rotate: Bool = false
    @AppStorage("GameClearData_Angle2") private var angle2: Bool = false
    
    @Published var startUnity: Bool = false
    @Published var showSetting: Bool = false
    @Published var showGameState: Bool = false
    @Published var showMap: Bool = false
    @Published private var successCount: Int = 0
    
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
    
    func calcuteProgress() -> Int {
        successCount = 0
        
        successCount += clicker ? 1 : 0
        successCount += angle1 ? 1 : 0
        successCount += order ? 1 : 0
        successCount += dodge ? 1 : 0
        successCount += major ? 1 : 0
        successCount += rotate ? 1 : 0
        successCount += angle2 ? 1 : 0
        
        return successCount / 7 * 100
    }
}
