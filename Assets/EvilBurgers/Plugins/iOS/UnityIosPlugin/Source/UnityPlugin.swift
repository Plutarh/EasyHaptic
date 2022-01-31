
import Foundation
import CoreHaptics
import AudioToolbox

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
            print("GERA Device not support CHHapticEngine");
            return;
        }
        
        do
        {
            engine = try CHHapticEngine();
        }
        catch let error
        {
            print("GERA ERROR");
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
           print("GERA Failed to play pattern: \(error.localizedDescription).")
        }
    }
    
    @objc public func PlayHaptic(type : Int) -> Void
    {
        
        
        switch (type)
        {
            case 1:
            let generator = UINotificationFeedbackGenerator()
            generator.notificationOccurred(.error)

            case 2:
            let generator = UINotificationFeedbackGenerator()
            generator.notificationOccurred(.success)

            case 3:
            let generator = UINotificationFeedbackGenerator()
            generator.notificationOccurred(.warning)

            case 4:
            let generator = UIImpactFeedbackGenerator(style: .light)
            generator.impactOccurred()

            case 5:
            let generator = UIImpactFeedbackGenerator(style: .medium)
            generator.impactOccurred()

            case 6:
            let generator = UIImpactFeedbackGenerator(style: .heavy)
            generator.impactOccurred()

            default:
            let generator = UISelectionFeedbackGenerator()
            generator.selectionChanged()
          
        }
    }
    
    public func PlayHapticIphone6(type : Int) -> Void
    {
        switch (type)
        {
            case 0:
                AudioServicesPlaySystemSound(1521);
                break;
            
            case 1:
                AudioServicesPlaySystemSound(1521);
                break;
            
            case 2:
                AudioServicesPlaySystemSound(1521);
                break;
            
            case 3:
                AudioServicesPlaySystemSound(1519);
                break;
            
            case 4:
                AudioServicesPlaySystemSound(1519);
                break;
            
            case 5:
                AudioServicesPlaySystemSound(1520);
                break;
            
            case 6:
                AudioServicesPlaySystemSound(1519);
                break;
            
            default:
                //Do nothing, should never reach here
                break;
        }
    }
}
