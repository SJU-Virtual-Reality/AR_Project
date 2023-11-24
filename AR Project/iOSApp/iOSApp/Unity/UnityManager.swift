//
//  UnityManager.swift
//  iOSApp
//
//  Created by 김도형 on 11/24/23.
//

import Foundation
import UnityFramework

class UnityManager {
    
    static let shared = UnityManager()
    
    private let dataBundleId: String = "com.unity3d.framework"
    private let frameworkPath: String = "/Frameworks/UnityFramework.framework"
    
    private var ufw: UnityFramework?
    
    private init() {}

    func launchUnity() {
        let isInitialized = self.ufw?.appController() != nil
        if isInitialized {
            self.ufw?.showUnityWindow()
        } else {
            guard let ufw = self.loadUnityFramework() else { return }
            self.ufw = ufw
            ufw.setDataBundleId(dataBundleId)
            ufw.runEmbedded(
                withArgc: CommandLine.argc,
                argv: CommandLine.unsafeArgv,
                appLaunchOpts: nil
            )
        }
    }

    private func loadUnityFramework() -> UnityFramework? {
        let bundlePath: String = Bundle.main.bundlePath + frameworkPath

        let bundle = Bundle(path: bundlePath)
        if bundle?.isLoaded == false {
            bundle?.load()
        }

        let ufw = bundle?.principalClass?.getInstance()
        if ufw?.appController() == nil {
            let machineHeader = UnsafeMutablePointer<MachHeader>.allocate(capacity: 1)
            machineHeader.pointee = _mh_execute_header

            ufw?.setExecuteHeader(machineHeader)
        }
        return ufw
    }
}
