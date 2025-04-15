import { useState, useEffect } from 'react';

const Clock = () => {
  const [currentTime, setCurrentTime] = useState(new Date());

  useEffect(() => {
    const timer = setInterval(() => {
      setCurrentTime(new Date());
    }, 1000); 
    return () => clearInterval(timer);
  }, []);

  return (
    <div className="clock-contenant">
      <p className="clock-text">
        {currentTime.toLocaleDateString()} - {currentTime.toLocaleTimeString()}
      </p>
    </div>
  );
};

export default Clock;
