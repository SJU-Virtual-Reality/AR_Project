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
    
    @AppStorage("GameClearData_Clicker") var clicker: String = "False"
    @AppStorage("GameClearData_Angle1") var angle1: String = "False"
    @AppStorage("GameClearData_Order") var order: String = "False"
    @AppStorage("GameClearData_Dodge") var dodge: String = "False"
    @AppStorage("GameClearData_Major") var major: String = "False"
    @AppStorage("GameClearData_Rotate") var rotate: String = "False"
    @AppStorage("GameClearData_Angle2") var angle2: String = "False"
    
    @Published var startUnity: Bool = false
    @Published var showSetting: Bool = false
    @Published var showGameState: Bool = false
    @Published var showMap: Bool = false
    @Published private var successCount: Float = 0
    
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
    
    func calcuteProgress() -> Float {
        successCount = 0
        
        successCount += clicker == "True" ? 1 : 0
        successCount += angle1 == "True" ? 1 : 0
        successCount += angle1 == "True" ? 1 : 0
        successCount += dodge == "True" ? 1 : 0
        successCount += major == "True" ? 1 : 0
        successCount += rotate == "True" ? 1 : 0
        successCount += angle2 == "True" ? 1 : 0
        
        print("clicker: \(clicker)")
        print("angle1: \(angle1)")
        print("order: \(order)")
        print("dodge: \(dodge)")
        print("major: \(major)")
        print("rotate: \(rotate)")
        print("angle2: \(angle2)")
        
        print(successCount / 7 * 100)
        
        return successCount / 7 * 100
    }
    
    func reset() {
        successCount = 0
        angle1 = "False"
        angle1 = "False"
        dodge = "False"
        major = "False"
        rotate = "False"
        clicker = "False"
        angle2 = "False"
        showGameState = false
        startUnity = false
        unityBridge?.unload()
    }
}
