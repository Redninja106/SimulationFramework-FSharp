open SimulationFramework
open SimulationFramework.Input
open SimulationFramework.Drawing
open SimulationFramework.Drawing.Shaders
open System.Numerics
open ImGuiNET

type MyShader() = 
    inherit CanvasShader()
    [<DefaultValue>] val mutable b: float32

    override this.GetPixelColor(position: Vector2): ColorF =
        ColorF (position.X / 500f, position.Y / 500f, this.b, 1f)


let mutable rot: float32 = 0f
let shader = MyShader();

let init() = ()

let render(canvas: ICanvas) = 
    canvas.Clear(Color.Black)
    
    ImGui.SliderFloat("blue", &shader.b, 0f, 1f) |> ignore;
    canvas.Fill(shader)

    canvas.Rotate(rot, Mouse.Position);
    rot <- rot + Time.DeltaTime
    
    canvas.DrawRect(Mouse.Position, new Vector2(250f, 250f), Alignment.Center);

Simulation.CreateAndRun(init, render);
