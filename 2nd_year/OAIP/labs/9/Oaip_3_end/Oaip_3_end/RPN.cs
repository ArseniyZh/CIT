using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace oaip_9
{
    static class RPN
    {
        private static bool IsOperator(string c)
        {
            if (c == "F" || c == "M" || c == "D")
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool CalculateRPN(string expression)
        {
            Stack<string> operandsStack = new Stack<string>();
            string temporary_storage = "";

            foreach (char c in expression)
            {
                if (c == '.' && temporary_storage == "")
                {
                    temporary_storage += ".";
                    
                }
                else if (c == '.')
                {
                    operandsStack.Push(temporary_storage);
                    temporary_storage = "";
                }
                else
                {
                    temporary_storage += c;
                }
                


            }
            operandsStack.Push(temporary_storage);

            
            if (IsOperator(operandsStack.Peek()))
            {
                return ApplyOperation(operandsStack, operandsStack.Pop());
            }
            return false;
        }


        private static bool ApplyOperation(Stack<string> operands, string c)
        {
            if (c == "F" && operands.Count == 5)
            {
                try
                {
                    House house = new House(operands.Pop(), Convert.ToInt32(operands.Pop()),
                    Convert.ToInt32(operands.Pop()), Convert.ToInt32(operands.Pop()),
                    Convert.ToInt32(operands.Pop()));

                    if ((house.h > 0 && house.w > 0) &&
                        (house.y >= 0 && house.y <= Init.pictureBox.Height) &&
                        (house.x >= 0 && house.x <= Init.pictureBox.Width) &&
                        (house.x + house.w <= Init.pictureBox.Width && house.y + house.h <= Init.pictureBox.Height))
                    {
                        bool rect_in_list = false;
                        foreach (House rec in ShapeContainer.figureList.ToArray())
                        {
                            if (rec.name == house.name)
                            {
                                rect_in_list = true;
                                MessageBox.Show("Прямоугольник с таким именем уже существует");
                                break;
                            }
                        }
                        if (!rect_in_list)
                        {
                            ShapeContainer.AddFigure(house);
                            house.Draw();
                            return true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ошибка");
                        return false;
                    }
                }
           
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            else if (c == "M" && operands.Count == 3)
            {
                try
                {
                    string name = operands.Pop();
                    if (!int.TryParse(operands.Pop(), out int dy) || !int.TryParse(operands.Pop(), out int dx))
                    {
                        MessageBox.Show("dx и dy должны быть целочисленными значениями");
                        return false;
                    }

                    bool in_list = false;
                    foreach (House house in ShapeContainer.figureList.ToArray())
                    {
                        if (house.name == name)
                        {
                            in_list = true;
                            house.MoveTo(dx, dy);
                        }
                    }
                    if (!in_list)
                    {
                        MessageBox.Show("Прямоугольник с таким именем не найден");
                        return false;
                    }
                    return true;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                
            }
            else if (c == "D" && operands.Count == 1)
            {
                try
                {
                    string name = operands.Pop();
                    bool in_list = false;
                    foreach (House house in ShapeContainer.figureList.ToArray())
                    {
                        if (house.name == name)
                        {
                            in_list = true;
                            Figure.DeleteF(house, true);
                        }
                    }
                    if (!in_list)
                    {
                        MessageBox.Show("Прямоугольник с таким именем не найден");
                        return false;
                    }
                    return true;
                } 
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }   
            }
            return false;
        }

    }
}
