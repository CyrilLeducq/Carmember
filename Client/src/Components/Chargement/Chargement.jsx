import { useEffect, useState } from "react";
import { DotLottieReact } from "@lottiefiles/dotlottie-react";

function Chargement() {
  const [show, setShow] = useState(true);

  useEffect(() => {
    const timer = setTimeout(() => {
      setShow(false);
    }, 3000); 

    return () => clearTimeout(timer); 
  }, []);

  return (
    <>
      {show && (
        <div style={{ width: "100%", height: "50vh", display: "flex", justifyContent: "center", alignItems: "center" }}>
          <DotLottieReact
            src="https://lottie.host/ca7a2970-63a7-4614-982a-610f6cb8527a/qd6lb8BOrB.lottie"
            loop
            autoplay
          />
        </div>
      )}
    </>
  );
}

export default Chargement;
