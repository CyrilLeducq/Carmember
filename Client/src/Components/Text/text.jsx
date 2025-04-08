import React from "react";

const Text = ({ text, className = "", fontSize = "1rem" }) => {
  const colors = ["#F7753D", "#1B998B", "#F5C45C"];
  let colorIndex = 0;

  return (
    <div className={className}>
      {text.split("").map((char, index) => {
        if (char === "\n") {
          return <br key={index} />;
        }

        const isSpace = char === " ";
        const style = {
          fontWeight: "bold",
          marginRight: isSpace ? "0.25em" : 0,
          color: isSpace ? "inherit" : colors[colorIndex % colors.length],
          fontSize: fontSize,
        };

        if (!isSpace) colorIndex++;

        return (
          <span key={index} style={style}>
            {char}
          </span>
        );
      })}
    </div>
  );
};

export default Text;
