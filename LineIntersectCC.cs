/* Ejercicio
1- Modelar una segmento de recta
3- Agregar el comportamiento a un segmento de recta que dado un punto devuelve la distancia al extremo más cercano
    //d = sqrt( (x2 - x1)^2 + (y2 - y1)^2 )
4- Modificar el comportamiento de 3 para devolver la distancia y además el extremo más cercano
5- Utilizar (implementar) la interfaz IComparable según el largo del segmento de recta
6- Refactorizar FasterLineSegmentIntersection
7- Modelar un poligono simple sin huecos que implemente el comportamiento de 4
8- Modelar una clase cliente que dado un punto y varias figuras geométricas como son 
   un segmento de recta o un poligono, devuelva el extremo más cercano.
9- Modelar el poligono de tal forma que sus puntos estén ordenados de forma horaria
*/

//Referencia Franklin Antonio. “Faster Line Segment Intersection”. In Graphics Gems III, Academic Press, 1992, pp. 199–202.
static bool FasterLineSegmentIntersection(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4) {*/
 
    Vector2 a = p2 - p1;
    Vector2 b = p3 - p4;
    Vector2 c = p1 - p3;
 
    float alphaNumerator = b.y*c.x - b.x*c.y;
    float alphaDenominator = a.y*b.x - a.x*b.y;
    float betaNumerator  = a.x*c.y - a.y*c.x;
    float betaDenominator  = a.y*b.x - a.x*b.y;
 
    bool i = true;
 
    if (alphaDenominator == 0 || betaDenominator == 0) {
        i = false;
    } else {
 
        if (alphaDenominator > 0) {
            if (alphaNumerator < 0 || alphaNumerator > alphaDenominator) {
                i = false;
            }
        } else if (alphaNumerator > 0 || alphaNumerator < alphaDenominator) {
            i = false;
        }
 
        if (i && betaDenominator > 0) {
            if (betaNumerator < 0 || betaNumerator > betaDenominator) {
                i = false;
            }
        } else if (betaNumerator > 0 || betaNumerator < betaDenominator) {
            i = false;
        }
    }

    if(i)
    {
        float Ua = alphaNumerator / alphaDenominator; //alpha of intersected point
        float x = p1.x + Ua * (p2.x - p1.x);
        float y = p1.y + Ua * (p2.y - p1.y);
        return new Vector2(x, y);
    }
 
    return null;
}