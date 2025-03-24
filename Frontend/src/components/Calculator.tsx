import React, { useState } from "react";
import { Button } from "./Button";

export const Calculator = () => {
    const [display, setDisplay] = useState("");

    const handleClick = (value: string) => {
        if (value === "=") {
            try { setDisplay(eval(display).toString()); } catch { setDisplay("Error"); }
        } else if (value === "C") {
            setDisplay("");
        } else {
            setDisplay(display + value);
        }
    };

    return (
        <div>
            <input type="text" value={display} readOnly />
            <div>
                {["7", "8", "9", "/", "4", "5", "6", "*", "1", "2", "3", "-", "0", "C", "=", "+"].map((btn) => (
                    <Button key={btn} label={btn} onClick={() => handleClick(btn)} />
                ))}
            </div>
        </div>
    );
};