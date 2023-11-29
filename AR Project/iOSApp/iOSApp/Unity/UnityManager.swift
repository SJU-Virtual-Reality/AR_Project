//
//  UnityManager.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import SwiftUI

class UnityManager: ObservableObject {
    @Published var startUnity: Bool = false
    @Published var showSetting: Bool = false
    @Published var showGameState: Bool = false
    
    weak var unityBridge: UnityBridge?
}
