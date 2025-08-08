const express = require("express");
const fs = require("fs/promises");
const cors = require("cors");

const app = express();
app.use(express.json());
app.use(cors());

const filePath = "./data.txt";
// const txt = "This is a sample text file.\n";

app.post("/write", async (req, res) => {
  try {
    const { content } = req.body;
    await fs.writeFile(filePath, content);
    res.send({ message: "File written successfully" });
  } catch (err) {
    res.status(500).send({ error: err.message });
  }
});

app.get("/read", async (req, res) => {
  try {
    const data = await fs.readFile(filePath, "utf8");
    res.send({ content: data });
  } catch (err) {
    res.status(500).send({ error: err.message });
  }
});

app.post("/rename", async (req, res) => {
  try {
    const { newName } = req.body;
    await fs.rename(filePath, newName);
    res.send({ message: "File renamed successfully" });
  } catch (err) {
    res.status(500).send({ error: err.message });
  }
});

app.delete("/delete", async (req, res) => {
  try {
    await fs.unlink(filePath);
    res.send({ message: "File deleted successfully" });
  } catch (err) {
    res.status(500).send({ error: err.message });
  }
});

app.listen(5000, () => console.log("Server running on http://localhost:5000"));
