using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

/// <summary>
/// I product.
/// </summary>
public interface IProduct{

		string ImageSource			{ get; set;}
		string ProductName			{ get; set;}
		string ProductLink			{ get; set;}
		string ProductPrice			{ get; set;}
		string ProductDescription	{ get; set;}
}

/// <summary>
/// Shop link.
/// </summary>
public class ShopLink : MonoBehaviour, IProduct {

	public 	string 		link		=	"http://looneybits.com";
	private string  	_name 		= 	"";
	private string  	_text 		= 	"";
	private string 		_price		=	"";
	private string		_imgLink	=	"";	
	private Transform 	_buttonBuy;
	private Transform	_inputName;
	private Transform	_inputDescription;
	private Transform 	_inputPrice;
	private Transform	_inputImage;
	
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void OnEnable()
	{
		_inputName 			= transform.Find ("ProductName");
		_inputImage 		= transform.Find ("ProductImageContainer");
		_inputDescription 	= transform.Find ("InputFieldDescription");
		_inputPrice			= transform.Find ("InputFieldPrice");
		_buttonBuy 			= transform.Find ("ButtonBuy");
	}
	
	/// <summary>
	/// Gets or sets the image source.
	/// </summary>
	/// <value>The image source.</value>
	public string ImageSource
	{
		get{return _imgLink;}
		set{
			_imgLink	=	value;
			//WWW www 	= 	new WWW(_imgLink);
			//StartCoroutine(WaitForRequest(www));
            StartCoroutine(GetRequest(_imgLink));
		}
	}
	
	/// <summary>
	/// Gets or sets the product link.
	/// </summary>
	/// <value>The product link.</value>
	public string ProductLink
	{
		get{return link;}
		set{
				link=value;
				if(_buttonBuy!=null)
				{
										_buttonBuy.GetComponent<LinkButton> ().link = link;			
				}
		}
	}

	/// <summary>
	/// Gets or sets the name of the product.
	/// </summary>
	/// <value>The name of the product.</value>
	public string ProductName
	{
			get{return _name;}
			set{
				_name	=	value;
				if(_inputName!=null)
				{
						_inputName.GetComponent<Text>().text=_name;
				}
			}
	}

	/// <summary>
	/// Gets or sets the product description.
	/// </summary>
	/// <value>The product description.</value>
	public string ProductDescription
	{
		get{return _text;}
		set{
			_text	=	value;
			if(_inputDescription!=null)
			{
				_inputDescription.GetComponent<InputField>().text=_text;
			}
		}
	}
	/// <summary>
	/// Gets or sets the product price.
	/// </summary>
	/// <value>The product price.</value>
	public string ProductPrice
	{
			get{return _price;}
			set{
					_price	=	value;
					if(_inputPrice!=null)
					{
						_inputPrice.GetComponent<InputField>().text=_price;
					}
			}
	}

    /// <summary>
	/// Waits for request.
	/// </summary>
	/// <returns>The for request.</returns>
	/// <param name="www">Www.</param>
	IEnumerator GetRequest(string uri)
    {
        using (UnityWebRequest webRequest = UnityWebRequestTexture.GetTexture(uri))
        {
            Transform msg = transform.Find("message");
            if (msg != null) { msg.gameObject.SetActive(true); }

            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
                Debug.Log("WWW Error: " + webRequest.error);
            }
            else
            {
                GameObject imageAux = _inputImage.transform.Find("Image").gameObject;
                if (imageAux != null)
                {
                    imageAux.GetComponent<Image>().sprite = Sprite.Create(((DownloadHandlerTexture)webRequest.downloadHandler).texture, new Rect(0, 0, ((DownloadHandlerTexture)webRequest.downloadHandler).texture.width, ((DownloadHandlerTexture)webRequest.downloadHandler).texture.height), new Vector2(0.5f, 0.5f));
                }
            }
        }
    }

}
