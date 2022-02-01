
import Foundation
import CoreHaptics
import AudioToolbox


@available(iOS 13.0, *)
@objc public class UnityPlugin : NSObject {
    
    @objc public static let shared = UnityPlugin()
    
   
    @objc public var engine : CHHapticEngine!;
    
    
    @objc public func IsHapticAvailable() -> Bool
    {
        return CHHapticEngine.capabilitiesForHardware().supportsHaptics;
    }
    
    @objc public func StartEngine() -> Void
    {
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
        
        engine?.start(completionHandler: { (error) in
            
         })
        
        engine?.stoppedHandler = { reason in
          print("Haptic engine stopped due to reason: \(reason)")
        }
        
        engine?.resetHandler = {
            
            print("Reset Handler: Restarting the engine.")
            
            do {
                print("Try restart haptic engine")
                try self.engine.start()

            } catch {
                fatalError("Failed to restart the Haptic engine: \(error)")
            }
        }
    }
    
    @objc public func PlayTestVib() -> Void
    {
        guard CHHapticEngine.capabilitiesForHardware().supportsHaptics else { return }

        let intensity = CHHapticEventParameter(parameterID: .hapticIntensity, value: 1)
        let sharpness = CHHapticEventParameter(parameterID: .hapticSharpness, value: 1)
        let event = CHHapticEvent(eventType: .hapticTransient, parameters: [intensity, sharpness], relativeTime: 0)
       
        
        do
        {
           let pattern = try CHHapticPattern(events: [event], parameters: [])
           let player = try engine?.makePlayer(with: pattern)
           try player?.start(atTime: 0)
            
        }
        catch
        {
           print("Failed to play pattern: \(error.localizedDescription).")
        }
    }
    
    @objc public func PlayCustom(intens:Float,sharp:Float ,dur: Double) -> Void
    {
        guard CHHapticEngine.capabilitiesForHardware().supportsHaptics else { return }

        let intensity = CHHapticEventParameter(parameterID: .hapticIntensity, value: intens)
        let sharpness = CHHapticEventParameter(parameterID: .hapticSharpness, value: sharp)
        //let event = CHHapticEvent(eventType: .hapticTransient, parameters: [intensity, sharpness], relativeTime: 0, duration: dur)
        
        let event = CHHapticEvent(eventType: dur > 0 ? .hapticContinuous : .hapticTransient, parameters: [intensity, sharpness], relativeTime: 0, duration: dur)
       
        
        do
        {
           let pattern = try CHHapticPattern(events: [event], parameters: [])
           let player = try engine?.makePlayer(with: pattern)
           try player?.start(atTime: 0)
            
        }
        catch
        {
           print("Failed to play pattern: \(error.localizedDescription).")
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
                AudioServicesPlaySystemSound(1519);
                break;
        }
    }
}

