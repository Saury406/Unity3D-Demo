using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Networking;

/// <summary>
/// Asset data.
/// </summary>
enum AssetData
{
	name		=	0,
	photo		=	1,
	price		=	2,
	link		=	3,
	description	=	4,

}
/// <summary>
/// Shop controller.
/// </summary>
public class ShopController : MonoBehaviour {
	public string url= "https://looneybits.github.io/projects/shop_test.txt";
	public string msgOnFail="Visit www.looneybits.com";

	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start () {
        StartCoroutine(GetRequest(url));
    }

    /// <summary>
    /// Waits for request
    /// </summary>
    /// <param name="uri"></param>
    /// <returns></returns>
    IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            Transform msg = transform.Find("message");
            if (msg != null) { msg.gameObject.SetActive(true); }

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                foreach (Transform child in transform)
                {
                    if (child.name != "logo" && child.name != "message") { child.gameObject.SetActive(false); }
                }
                if (msg != null) { msg.GetComponent<Text>().text = msgOnFail; }
                Debug.Log("WWW Error: " + webRequest.error);
            }else{
                ShowProducts(webRequest.downloadHandler.text);
                if (msg != null) { msg.gameObject.SetActive(false); }
            }
        }
    }

    /// <summary>
    /// Shows the products.
    /// </summary>
    /// <param name="data">Data.</param>
    void ShowProducts(string data)
	{
		/*string dataTest = 
				"ParkingSimulator,https://d2ujflorbtfzji.cloudfront.net/key-image/33e2663d-b62d-4ad4-b32d-9e0bd7988f7e.png,10.00,http://u3d.as/jkP,#product1 #superproduct1 #description\n" +
				"SuperGoalKeeper,https://d2ujflorbtfzji.cloudfront.net/key-image/b27d0f88-d6d1-49ef-877d-2ce404b2a3d6.png,09.99,http://u3d.as/7Ur,#supergoalkeepr #soccer #goal\n" 			+
				"SuperPunch,https://d2ujflorbtfzji.cloudfront.net/key-image/e6540ce7-c780-4c3d-b863-9326a69f5cfb.png,14.99,http://u3d.as/8zu,#superpunch #punch #ko\n" 						+
				"DieselGateTheGame,https://d2ujflorbtfzji.cloudfront.net/key-image/332c153d-3511-47ec-a94e-223291035147.png,09.00,http://u3d.as/95D,#dieselgate #dieselgatethegame\n" 		+
				"2DSoccerPack,https://d2ujflorbtfzji.cloudfront.net/key-image/c95e4e78-94f4-4d58-9603-dd667ae3218f.png,0.99,http://u3d.as/7VC,#soccerPack #packSoccer #football\n" 			+
				"RaceCars2D,https://d2ujflorbtfzji.cloudfront.net/key-image/04881eca-aff6-4acb-a23e-575ff5f4276e.png,00.00,http://u3d.as/7Sz,#racecar #racing #race";
		*/

		string[,] 	sData		=	CSVReader.SplitCsvGrid (data);	//CSVReader.SplitCsvGrid (dataTest);	
		for(int i=0;i<sData.GetUpperBound(1);i++)
		{
			Transform element=transform.Find("Product"+i);
			if(element!=null)
			{
				element.GetComponent<IProduct>().ProductName		=sData[(int)AssetData.name			,i];
				element.GetComponent<IProduct>().ProductLink		=sData[(int)AssetData.link			,i];
				element.GetComponent<IProduct>().ProductPrice		=sData[(int)AssetData.price			,i];
				element.GetComponent<IProduct>().ProductDescription	=sData[(int)AssetData.description	,i];
				element.GetComponent<IProduct>().ImageSource		=sData[(int)AssetData.photo			,i];
			}
		}
	}
}
