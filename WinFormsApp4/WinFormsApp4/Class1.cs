using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WinFormsApp4
{
    public class Class1
    {
        private readonly static string[] RESERVED = { "repeat", "until", "and", "or" };

        // индекс текущего анализируемого символа
        private int pos;
        // входная строка
        private string str;
        // строка вывода сообщения об ошибки
        private string errorMes;
        // индекс ошибки в строке
        private int errorPos;
        // список идентификаторов
        private LinkedList<string> id;
        // список констант
        private LinkedList<string> consts;

        private enum State // перечисление состояний
        {
            S, E, F, S1, S12, S13, S14, S15, S16, S2, S3, S4, S41, S42, S43, S44, S45, S5, S6, S7,
            A, A1, A2, P, P1, P2, K, K1, K2, K3, K4, K5, K6, Y, Y1, Y2, Y3, Y4, Y5, Y6, Y7, Y8, Y9, Y10, Y11,Y13,
            Y12,
            Y21,
            Y14,
            Y15,
            Y16,
            Y41,
            Y43,
            Y42,
            Y51,
            Y44,
            Y45,
            Y46,
            Y71,
            Y73,
            Y72,
            Y81,
            Y74,
            Y75,
            Y101,
            X1,
            X2,
            X11,
            X12,
            Y76,
        }
        public Class1(string str)
        {
            pos = 0;
            errorMes = "";
            errorPos = -1;
            id = new LinkedList<string>();
            consts = new LinkedList<string>();
            this.str = str;
            AnalyseStr();
        }
        public int ErrorPos
        {
            get
            {
                return errorPos;
            }
        }
        public string ErrorMes
        {
            get
            {
                return errorMes;
            }
        }

        public LinkedList<string> Id
        {
            get
            {
                return id;
            }
        }

        public LinkedList<string> Consts
        {
            get
            {
                return consts;
            }
        }
        private bool AnalyseStr()
        {
            State state = State.S;
            string identifier = string.Empty;
            string constant = string.Empty;
            errorMes = "";
            while (state != State.E && state != State.F)
            {
                if (pos >= str.Length)
                {
                    errorMes = "Непредвиденный конец строки";
                    state = State.E;
                    break;
                }
                char ch = char.ToLower(str[pos]);
                switch (state)
                {
                    case State.S:
                        {
                            if (ch == 'r')
                            {
                                state = State.S1;
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: R или пробел";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S1:
                        {
                            if (ch == 'e')
                            {
                                state = State.S12;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: E";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S12:
                        {
                            if (ch == 'p')
                            {
                                state = State.S13;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: P";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S13:
                        {
                            if (ch == 'e')
                            {
                                state = State.S14;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: E";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S14:
                        {
                            if (ch == 'a')
                            {
                                state = State.S15;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: A";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S15:
                        {
                            if (ch == 't')
                            {
                                state = State.S16;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: T";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S16:
                        {
                            if (ch == ' ')
                            {
                                state = State.A;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел";
                                state = State.E;
                            }
                            break;
                        }
                    case State.A:
                        {
                            if (char.IsLetter(ch))
                            {
                                state = State.A1;
                                identifier = ch.ToString();
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел или буква";
                                state = State.E;
                            }
                            break;
                        }
                    case State.A1:
                        {
                            if (char.IsLetterOrDigit(ch))
                            {
                                identifier += ch.ToString();
                            }
                            else
                            {
                                if (identifier.Length > 8)
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может иметь длину более 8 символов";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!CheckInd(identifier))
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может быть словом AHD, OR, REPEAT, UNTIL";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!id.Contains(identifier))
                                    id.AddLast(identifier);
                                if (ch == ' ')
                                {
                                    state = State.S2;
                                }
                                else if (ch == ':')
                                {
                                    state = State.S3;
                                }
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: Пробел, :, цифра, буква, ";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.S2:
                        {
                            if (ch == ':')
                            {
                                state = State.S3;
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: Пробел, : ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S3:
                        {
                            if (ch == '=')
                                state = State.P;
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: =";
                                state = State.E;
                            }
                            break;
                        }
                    case State.P:
                        {
                            if (ch == '-')
                            {
                                constant = ch.ToString();
                                state = State.K1;
                            }
                            else if (ch == '+')
                            {
                                constant = ch.ToString();
                                state = State.K1;
                            }
                            else if (ch == '0')
                            {
                                constant = ch.ToString();
                                state = State.K3;
                            }

                            else if (char.IsDigit(ch))
                            {
                                constant = ch.ToString();
                                state = State.K2;
                            }
                            else if (char.IsLetter(ch))
                            {
                                identifier = ch.ToString();
                                state = State.P1;
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, буква, +, -";
                                state = State.E;
                            }
                            break;
                        }
                    case State.P1:
                        {
                            if (char.IsLetterOrDigit(ch))
                                identifier += ch;
                            else
                            {
                                if (identifier.Length > 8)
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может иметь длину более 8 символов";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!CheckInd(identifier))
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может быть словом AHD, OR, REPEAT, UNTIL";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!id.Contains(identifier))
                                    id.AddLast(identifier);
                                if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                                    state = State.P;
                                else if (ch == ' ')
                                {
                                    state = State.S4;
                                }
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, буква, +|-|*|/";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.K1:
                        {
                            if (ch == '0')
                            {
                                constant += ch.ToString();
                                state = State.K4;
                            }
                            else if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.K2;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.K3:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.K5;
                            }
                            else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                            {
                                consts.AddLast(constant);
                                state = State.P;
                            }
                            else if (ch == ' ')
                            {
                                consts.AddLast(constant);
                                state = State.S4;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, точка, +|-|*|/";
                                state = State.E;
                            }
                            break;
                        }
                    case State.K2:
                        {
                            if (char.IsDigit(ch))
                                constant += ch;
                            else
                            {
                                if (ch == '.')
                                {
                                    constant += ch.ToString();
                                    state = State.K5;
                                }
                                else
                                {
                                    if (!CheckConst(constant))
                                    {
                                        errorMes = "Семантическая ошибка.\nЗначение константы не входит в диапазон -32768..32767";
                                        pos = pos - constant.Length;
                                        state = State.E;
                                        break;
                                    }
                                    if (!consts.Contains(constant))
                                        consts.AddLast(constant);
                                    if (ch == ' ')
                                        state = State.S4;
                                    else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                                        state = State.P;
                                    else
                                    {
                                        errorMes = "Синтаксическая ошибка.\nОжидалось: пробел, цифра, точка, +|-|*|/";
                                        state = State.E;
                                    }
                                }
                            }
                            break;
                        }
                    case State.K4:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.K5;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: точка";
                                state = State.E;
                            }
                            break;
                        }
                    case State.K5:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.K6;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.K6:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                            }
                            else
                            {
                                if (!consts.Contains(constant))
                                    consts.AddLast(constant);
                                if (ch == ' ')
                                    state = State.S4;
                                else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                                    state = State.P;
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, +|-|*|/";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.S4:
                        {
                            if (ch == 'u')
                            {
                                state = State.S41;
                            }
                            else if (ch == '+' || ch == '-' || ch == '*' || ch == '/')
                                state = State.P;
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, U , +|-|*|/";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S41:
                        {
                            if (ch == 'n')
                            {
                                state = State.S42;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: N ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S42:
                        {
                            if (ch == 't')
                            {
                                state = State.S43;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: T ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S43:
                        {
                            if (ch == 'i')
                            {
                                state = State.S44;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: I ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S44:
                        {
                            if (ch == 'l')
                            {
                                state = State.S5;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: L ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.S5:
                        {
                            if (ch == ' ')
                            {
                                state = State.Y;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y:
                        {
                            if (ch == '-')
                            {
                                constant = ch.ToString();
                                state = State.Y11;
                            }
                            else if (ch == '+')
                            {
                                constant = ch.ToString();
                                state = State.Y11;
                            }
                            else if (ch == '0')
                            {
                                constant = ch.ToString();
                                state = State.Y13;
                            }

                            else if (char.IsDigit(ch))
                            {
                                constant = ch.ToString();
                                state = State.Y12;
                            }
                            else if (char.IsLetter(ch))
                            {
                                identifier = ch.ToString();
                                state = State.Y21;
                            }
                            else if (ch == '(')
                            {
                                state = State.Y3;
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, буква, +, -, (";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y11:
                        {
                            if (ch == '0')
                            {
                                constant += ch;
                                state = State.Y14;
                            }
                            else if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.Y12;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y13:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.Y15;
                            }
                            else if (ch == ' ')
                            {
                                consts.AddLast(constant);
                                state = State.S6;
                            }
                            else if (ch == ';')
                            {
                                consts.AddLast(constant);
                                state = State.F;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, точка, ; ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y12:
                        {
                            if (char.IsDigit(ch))
                                constant += ch;
                            else
                            {
                                if (ch == '.')
                                {
                                    constant += ch.ToString();
                                    state = State.Y15;
                                }
                                else
                                {
                                    if (!CheckConst(constant))
                                    {
                                        errorMes = "Семантическая ошибка.\nЗначение константы не входит в диапазон -32768..32767";
                                        pos = pos - constant.Length;
                                        state = State.E;
                                        break;
                                    }
                                    if (!consts.Contains(constant))
                                        consts.AddLast(constant);
                                    if (ch == ' ')
                                        state = State.S6;
                                    else if (ch == ';')
                                        state = State.F;
                                    else
                                    {
                                        errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, точка, ; ";
                                        state = State.E;
                                    }
                                }
                            }
                            break;
                        }
                    case State.Y21:
                        {
                            if (char.IsLetterOrDigit(ch))
                                identifier += ch;
                            else
                            {
                                if (identifier.Length > 8)
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может иметь длину более 8 символов";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!CheckInd(identifier))
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может быть словом AHD, OR, REPEAT, UNTIL";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!id.Contains(identifier))
                                    id.AddLast(identifier);
                                if (ch == ' ')
                                    state = State.S6;
                                else if (ch == ';')
                                {
                                    state = State.F;
                                }
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, буква, ; ";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.Y14:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.Y15;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: точка";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y15:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.Y16;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y16:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                            }
                            else
                            {
                                if (!consts.Contains(constant))
                                    consts.AddLast(constant);
                                if (ch == ' ')
                                    state = State.S6;
                                else if (ch == ';')
                                    state = State.F;
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, ; ";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.Y3:
                        {
                            if (ch == '-')
                            {
                                constant = ch.ToString();
                                state = State.Y41;
                            }
                            else if (ch == '+')
                            {
                                constant = ch.ToString();
                                state = State.Y41;
                            }
                            else if (ch == '0')
                            {
                                constant = ch.ToString();
                                state = State.Y43;
                            }

                            else if (char.IsDigit(ch))
                            {
                                constant = ch.ToString();
                                state = State.Y42;
                            }
                            else if (char.IsLetter(ch))
                            {
                                identifier = ch.ToString();
                                state = State.Y51;
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, буква, +, -";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y41:
                        {
                            if (ch == '0')
                            {
                                constant += ch;
                                state = State.Y44;
                            }
                            else if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.Y42;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y43:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.Y45;
                            }
                            else if (ch == ' ')
                            {
                                consts.AddLast(constant);
                                state = State.Y4;
                            }
                            else if (ch == ')')
                            {
                                consts.AddLast(constant);
                                state = State.S6;
                            }
                            else if (ch == '<' | ch == '>' | ch == '=')
                            {
                                consts.AddLast(constant);
                                state = State.Y6;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, точка, ), <|>|= ";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y42:
                        {
                            if (char.IsDigit(ch))
                                constant += ch;
                            else
                            {
                                if (ch == '.')
                                {
                                    constant += ch.ToString();
                                    state = State.Y45;
                                }
                                else
                                {
                                    if (!CheckConst(constant))
                                    {
                                        errorMes = "Семантическая ошибка.\nЗначение константы не входит в диапазон -32768..32767";
                                        pos = pos - constant.Length;
                                        state = State.E;
                                        break;
                                    }
                                    if (!consts.Contains(constant))
                                        consts.AddLast(constant);
                                    if (ch == ' ')
                                        state = State.Y4;
                                    else if (ch == ')')
                                        state = State.S6;
                                    else if (ch == '<' | ch == '>' | ch == '=')
                                        state = State.Y6;
                                    else
                                    {
                                        errorMes = "Синтаксическая ошибка.\nОжидалось: пробел, цифра, точка, ), <|>|=";
                                        state = State.E;
                                    }
                                }
                            }
                            break;
                        }
                    case State.Y51:
                        {
                            if (char.IsLetterOrDigit(ch))
                                identifier += ch;
                            else
                            {
                                if (identifier.Length > 8)
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может иметь длину более 8 символов";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!CheckInd(identifier))
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может быть словом AHD, OR, REPEAT, UNTIL";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!id.Contains(identifier))
                                    id.AddLast(identifier);
                                if (ch == ' ')
                                    state = State.Y5;
                                else if (ch == ')')
                                {
                                    state = State.S6;
                                }
                                else if (ch == '<' | ch == '>' | ch == '=')
                                    state = State.Y6;
                                else
                                {
                                    errorMes = "Синтаксическая ошибка.\nОжидалось: пробел, цифра, буква, ), <|>|=";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.Y44:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.Y45;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: точка";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y45:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.Y46;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y46:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                            }
                            else
                            {
                                if (!consts.Contains(constant))
                                    consts.AddLast(constant);
                                if (ch == ' ')
                                    state = State.Y4;
                                else if (ch == ')')
                                    state = State.S6;
                                else if (ch == '<' | ch == '>' | ch == '=')
                                    state = State.Y6;
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, ), <|>|= ";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.Y4:
                        {
                            if (ch == '<' | ch == '>' | ch == '=')
                                state = State.Y6;
                            else if (ch == ')')
                                state = State.S6;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, ), <|>|= ";
                            }
                            break;
                        }
                    case State.Y5:
                        {
                            if (ch == '<' | ch == '>' | ch == '=')
                                state = State.Y6;
                            else if (ch == ')')
                                state = State.S6;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, ), <|>|= ";
                            }
                            break;
                        }
                    case State.Y6:
                        {
                            if (ch == '-')
                            {
                                constant = ch.ToString();
                                state = State.Y71;
                            }
                            else if (ch == '+')
                            {
                                constant = ch.ToString();
                                state = State.Y71;
                            }
                            else if (ch == '0')
                            {
                                constant = ch.ToString();
                                state = State.Y73;
                            }

                            else if (char.IsDigit(ch))
                            {
                                constant = ch.ToString();
                                state = State.Y72;
                            }
                            else if (char.IsLetter(ch))
                            {
                                identifier = ch.ToString();
                                state = State.Y81;
                            }
                            else if (ch != ' ')
                            {
                                errorMes = "Синтаксическая ошибка.\nОжидалось: пробел, цифра, буква, +, -";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y71:
                        {
                            if (ch == '0')
                            {
                                constant += ch;
                                state = State.Y74;
                            }
                            else if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.Y72;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y73:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.Y75;
                            }
                            else if (ch == ' ')
                            {
                                consts.AddLast(constant);
                                state = State.Y7;
                            }
                            else if (ch == ')')
                            {
                                consts.AddLast(constant);
                                state = State.Y9;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, точка, )";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y72:
                        {
                            if (char.IsDigit(ch))
                                constant += ch;
                            else
                            {
                                if (ch == '.')
                                {
                                    constant += ch.ToString();
                                    state = State.Y75;
                                }
                                else
                                {
                                    if (!CheckConst(constant))
                                    {
                                        errorMes = "Семантическая ошибка\nЗначение константы не входит в диапазон -32768..32767";
                                        pos = pos - constant.Length;
                                        state = State.E;
                                        break;
                                    }
                                    if (!consts.Contains(constant))
                                        consts.AddLast(constant);
                                    if (ch == ' ')
                                        state = State.Y7;
                                    else if (ch == ')')
                                        state = State.Y9;
                                    else
                                    {
                                        errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, точка, )";
                                        state = State.E;
                                    }
                                }
                            }
                            break;
                        }
                    case State.Y81:
                        {
                            if (char.IsLetterOrDigit(ch))
                                identifier += ch;
                            else
                            {
                                if (identifier.Length > 8)
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может иметь длину более 8 символов";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!CheckInd(identifier))
                                {
                                    errorMes = "Семантическая ошибка.\nИдентификатор не может быть словом AHD, OR, REPEAT, UNTIL";
                                    pos = pos - identifier.Length;
                                    state = State.E;
                                    break;
                                }
                                if (!id.Contains(identifier))
                                    id.AddLast(identifier);
                                if (ch == ' ')
                                    state = State.Y8;
                                else if (ch == ')')
                                {
                                    state = State.Y9;
                                }
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, буква, )";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.Y74:
                        {
                            if (ch == '.')
                            {
                                constant += ch.ToString();
                                state = State.Y75;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: точка";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y75:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                                state = State.Y76;
                            }
                            else
                            {
                                errorMes = "Синтаксическая ошибка. Ожидалось: цифра";
                                state = State.E;
                            }
                            break;
                        }
                    case State.Y76:
                        {
                            if (char.IsDigit(ch))
                            {
                                constant += ch;
                            }
                            else
                            {
                                if (!consts.Contains(constant))
                                    consts.AddLast(constant);
                                if (ch == ' ')
                                    state = State.Y7;
                                else if (ch == ')')
                                    state = State.Y9;
                                else
                                {
                                    errorMes = "Синтаксическая ошибка. Ожидалось: пробел, цифра, )";
                                    state = State.E;
                                }
                            }
                            break;
                        }
                    case State.Y7:
                        {
                            if (ch == ')')
                                state = State.Y9;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, )";
                            }
                            break;
                        }
                    case State.Y8:
                        {
                            if (ch == ')')
                                state = State.Y9;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, )";
                            }
                            break;
                        }
                    case State.Y9:
                        {
                            if (ch == ';')
                                state = State.F;
                            else if (ch == 'a')
                                state = State.X1;
                            else if (ch == 'o')
                                state = State.X2;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, ;, A, O";
                            }
                            break;
                        }
                    case State.X1:
                        {
                            if (ch == 'n')
                                state = State.X11;
                            else
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: N";
                            }
                            break;
                        }
                    case State.X11:
                        {
                            if (ch == 'd')
                                state = State.Y10;
                            else
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: D";
                            }
                            break;
                        }
                    case State.Y10:
                        {
                            if (ch == '(')
                                state = State.Y3;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, (";
                            }
                            break;
                        }
                    case State.X2:
                        {
                            if (ch == 'r')
                                state = State.Y10;
                            else
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: R";
                            }
                            break;
                        }
                    case State.S6:
                        {
                            if (ch == ';')
                                state = State.F;
                            else if (ch != ' ')
                            {
                                state = State.E;
                                errorMes = "Синтаксическая ошибка. Ожидалось: пробел, ;";
                            }
                            break;
                        }
                    default:
                        {
                            errorMes = "Неизвестная ошибка";
                            state = State.E;
                            break;
                        }
                }
                pos++;
            }
            if (state == State.E)
            {
                errorPos = pos - 1;
            }
            return state == State.F;
        }
        private static bool CheckInd(string identifier)
        {
            return Array.IndexOf(RESERVED, identifier) == -1;
        }
        private static bool CheckConst(string constant)
        {
            return short.TryParse(constant, out _);
        }
    }
}

