
using System.Collections.Generic;
using System;
using System.Drawing;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Windows.Forms;
using System.Collections;
using System.Linq;


using Engine;

// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.ClientDataBase.ClearResource(System.Int32)")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.ClientDataBase.ClearShop(System.Int32)")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.ClientDataBase.ClearSkill(System.Int32)")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorAutoTiles.DrawAutoTile(System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Int32,System.Boolean,System.Boolean)")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorEventSystem.DrawEvents")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorGraphics.DrawMapTint")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorGraphics.DrawTileOutline")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorHousing.DrawFurniture(System.Int32,System.Int32)")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorTCP.Connect")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorText.DrawText(System.Int32,System.Int32,System.String,SFML.Graphics.Color,SFML.Graphics.Color,SFML.Graphics.RenderWindow@,System.Byte)")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorWeather.DrawFog")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0017:Simplify object initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorWeather.DrawThunderEffect")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0027:Simplify collection initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorHandleData.InitMessages")]
[assembly:System.Diagnostics.CodeAnalysis.SuppressMessage("Style","IDE0028:Simplify collection initialization",Justification="<Pending>",Scope="member",Target="~M:Editors.EditorHandleData.InitMessages")]
