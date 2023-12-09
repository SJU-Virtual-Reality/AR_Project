//
//  SoundSetting.swift
//  iOSApp
//
//  Created by 김도형 on 12/9/23.
//

import SwiftUI
import AVKit

class SoundManager: ObservableObject {
    static let getInstanse = SoundManager()
    var player: AVAudioPlayer?
    
    func playSound() {
        guard let url = Bundle.main.url(forResource: "ClickSound", withExtension: ".mp3") else {
            return
        }
        
        player = try? .init(contentsOf: url)
        player?.play()
    }
}
