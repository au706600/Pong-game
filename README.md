# 🕹️ Good Old Classic Pong Game - Windows Forms Edition 

A good old Pong game built using **C# and Windows Forms**, where the player plays against a computer-controlled paddle.

## 📚 Table of Contents

- [📘 Project Description](#-project-description)
- [✨ Features](#-features)
- [🛠️ Tech Stack](#-tech-stack)
- [▶️ Installation](#️-installation)
- [🧱 Directory Structure of Pong Game](#-directory-structure-of-pong-game)
- [🎮 Gameplay Controls](#-gameplay-controls)
- [📸 Demo](#-demo)
- [📌 Future Work](#-future-work)

## 📘 Project Description

This is a Windows Forms-based Pong game that features smooth paddle control, basic AI for the computer paddle, score tracking, and collision physics. The game logic is implemented using C# timers, `PictureBox` elements, and event-driven programming.

The ball bounces between the two paddles, and players score when the opponent fails to return the ball and the ball moves past the opponent. The game includes a simple AI opponent and boundary constraints.

## ✨ Features

- 🎮 Player-controlled paddle (move using `Up` and `Down` keys)
- 🧠 AI-controlled opponent
- 🧱 Ball bounces off paddles and top/bottom walls
- 🧾 Score tracking for both player and computer
- ⏯️ Pause (`P`) and Resume (`O`) game
- ✅ Boundaries (no moving off-screen)

## 🛠️ Tech Stack

- **Language:** C#
- **Framework:** .NET / Windows Forms
- **IDE:** Visual Studio 2022

## ▶️ Installation

1. **Clone the Repository**
   If you haven't yet, first set up Git and authentication with GitHub.com from Git. For more information, please see <a href="https://docs.github.com/en/get-started/git-basics/set-up-git">Set up Git</a>. Click      on <> Code and copy the URL of the repository that should look like the following:
   
   ```bash
   git clone https://github.com/your-username/pong-game.git
   ```
   
2. **Open Git Bash in whatever local file location in your computer and run the following:**

   ```bash
   git clone https://github.com/your-username/pong-game.git
   cd pong-game
   ```

3. **Open the project in visual studio 2022**
   - Double-click on Pong-game.sln or open the folder from visual studio 2022.

4. **Run the application**
   - Click on **Start** in visual studio 2022 to run the game. 


## 🧱 Directory Structure of Pong Game
```
├── Pong-game/
│   ├── Properties/
│   │   ├── AssemblyInfo.cs
│   │   ├── Resources.Designer.cs
│   │   ├── Resources.resx
│   │   ├── Settings.Designer.cs
│   ├── App.config
│   ├── Form1.Designer.cs # Windows Forms UI components
│   ├── Form1.cs # Main game logic (Ball movement, AI, etc.)
│   ├── Form1.resx
│   ├── Pong-game.csproj
│   ├── Program.cs 
├── .gitattributes
├── .gitignore
├── Pong-game.sln

```

## 🎮 Gameplay Controls
- Move the paddle up using the **↑** key. 
- Move the paddle down using the **↓** key. 
- Pause the game using the **P** key. 
- Resume the game using the **O** key. 

## 🎥 Demo

### Gameplay UI when playing the game. The player is on the right and the computer is on the left:

<img width="907" height="527" alt="image" src="https://github.com/user-attachments/assets/a18ea39e-b9e8-4063-930c-4dce0608f162" />

## 📌 Future Work

Even though our game has different features, there are still some possible future work to be done: 

- 🔊 Add sound effects on paddle hits and scoring. 
- 🎚️ Add difficulty levels (e.g., Easy, Medium, Hard).
- 🧑‍🤝‍🧑 Maybe add multiplayer mode. 
