using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public Transform left;
    public Transform right;
    public GameObject one;

    public SpriteRenderer[] more;

    private static BirdManger _hadClick;
    private const int Width = 8;
    private const int Height = 6;
    private BirdManger[,] map = new BirdManger[Height, Width];

    void Start()
    {
        one.SetActive(false);

        var spritePosition = one.GetComponent<Transform>().position;
        var positionX = spritePosition.x;
        var positionY = spritePosition.y;
        var positionZ = spritePosition.z;

        var spriteSize = one.GetComponent<Renderer>().bounds.size;
        var sizeX = spriteSize.x;
        var sizeY = spriteSize.y;

        var startPosition = left.position;
        var startX = startPosition.x;
        var startY = startPosition.y;

        var endPosition = right.position;
        var endX = endPosition.x;
        var endY = endPosition.y;

        var blockX = positionX - startX;
        var blockY = positionY - startY;

        var rd = new Random();

        for (var i = 0; i < Width; i++)
        {
            var paintX = startX + (2 * i + 1) * blockX;
            // if (paintX + sizeX >= endX)
            // {
            //     break;
            // }

            for (var j = 0; j < Height; j++)
            {
                var paintY = startY + (2 * j + 1) * blockY;
                // if (paintY + sizeY <= endY)
                // {
                //     break;
                // }

                var type = rd.Next(0, more.Length);
                var newOne = Instantiate(one, new Vector3(paintX, paintY, positionZ), Quaternion.identity);
                newOne.GetComponent<SpriteRenderer>().sprite =
                    more[type].GetComponent<SpriteRenderer>().sprite;
                var birdManger = newOne.GetComponent<BirdManger>();
                birdManger.SetInfo(i, j, type);
                newOne.SetActive(true);
                map[j, i] = birdManger;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void BirdClick(BirdManger birdManger)
    {
        if (_hadClick == null)
        {
            _hadClick = birdManger;
            birdManger.ShakeStart();
            return;
        }

        _hadClick.ShakeStop();
        _hadClick.Delete();
        _hadClick = null;

        birdManger.Delete();
    }
}