
import Foundation
import CoreHaptics

@available(iOS 13.0, *)
@objc public class UnityPlugin : NSObject {
    
    @objc public static let shared = UnityPlugin()
    
    
    @objc public var engine : CHHapticEngine!;
    
    @objc public func AddTwoNumber(a:Int,b:Int ) -> Int {
           
           let result = a+b;
           return result;
       }
    
    
    @objc public func StartEngine() -> Void
    {
        print("GERA TEST START INIT");
        guard CHHapticEngine.capabilitiesForHardware().supportsHaptics else
        {
            print("Device not support CHHapticEngine");
            return;
        }
        
        do
        {
            engine = try CHHapticEngine();
        }
        catch let error
        {
            dump(error);
        }
        print("GERA TEST INIT");
    }
    
    @objc public func PlayTestVib() -> Void
    {
        let short1 = CHHapticEvent(eventType: .hapticTransient, parameters: [], relativeTime: 0)
        let short2 = CHHapticEvent(eventType: .hapticTransient, parameters: [], relativeTime: 0.2)
        let short3 = CHHapticEvent(eventType: .hapticTransient, parameters: [], relativeTime: 0.4)
        let long1 = CHHapticEvent(eventType: .hapticContinuous, parameters: [], relativeTime: 0.6, duration: 0.5)
        let long2 = CHHapticEvent(eventType: .hapticContinuous, parameters: [], relativeTime: 1.2, duration: 0.5)
        let long3 = CHHapticEvent(eventType: .hapticContinuous, parameters: [], relativeTime: 1.8, duration: 0.5)
        let short4 = CHHapticEvent(eventType: .hapticTransient, parameters: [], relativeTime: 2.4)
        let short5 = CHHapticEvent(eventType: .hapticTransient, parameters: [], relativeTime: 2.6)
        let short6 = CHHapticEvent(eventType: .hapticTransient, parameters: [], relativeTime: 2.8)

        do {
           let pattern = try CHHapticPattern(events: [short1, short2, short3, long1, long2, long3, short4, short5, short6], parameters: [])
           let player = try engine?.makePlayer(with: pattern)
           try player?.start(atTime: 0)
        } catch {
           print("Failed to play pattern: \(error.localizedDescription).")
        }
    }
}
